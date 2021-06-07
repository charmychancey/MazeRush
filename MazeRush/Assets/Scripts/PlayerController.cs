using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MazeRush;
using UnityEngine.SceneManagement;

namespace MazeRush
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject Phone;
        [SerializeField] public Animator Animator;
        [SerializeField] public Text BatteryLevelDisplay;
        [SerializeField] public int MaxHealth = 100;
        [SerializeField] public AudioSource AudioSourceBackground;
        [SerializeField] public float StartingVolume= 0.15f;
        [SerializeField] public AudioSource AudioSourceFootsteps;
        [SerializeField] public AudioSource AudioSourceLight;
        [SerializeField] public AudioSource AudioSourceEndgame;

        private MovePlayer MovePlayer;
        private UseFlashlight Fire1;
        private IBattery Battery;
        private float StartingCharge;
        private float BackgroundAudioGrowthRate;
        public int currentHealth;
        [SerializeField] public HealthBar healthbar;
        private bool GameOver;
        private Rigidbody PlayerBody;

        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UseFlashlight>();
            this.Battery = new DefaultBattery();
            currentHealth = MaxHealth;
            healthbar.SetMaxHealth(MaxHealth);
            this.Animator = this.gameObject.GetComponentInChildren<Animator>();
            this.PlayerBody = this.gameObject.GetComponent<Rigidbody>();

            // Sets init conditions for Audio logic variables.
            this.AudioSourceBackground.volume = this.StartingVolume;
            this.StartingCharge = this.Battery.GetCharge();
            this.BackgroundAudioGrowthRate =
                Mathf.Pow(1/this.StartingVolume,
                          1/this.StartingCharge) -
                1;
            this.GameOver=false;
        }

        // Update is called once per frame
        void Update()
        {
            AimAtMouse();
            DoUseFlashlight();
            DoDrainBattery();
            this.BatteryLevelDisplay.text =
                Mathf.Ceil(this.Battery.GetCharge()).ToString("F0")+ "%";
            TakeDamage();
            PlayAudios();
        }

        void TakeDamage()
        {
            healthbar.SetHealth((int)this.Battery.GetCharge());
        }

        private void FixedUpdate() {
            DoPlayerMovement();
        }

        private void DoPlayerMovement()
        {
            if (Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0)
            {
                this.MovePlayer.Execute(this.gameObject);
                this.Animator.SetBool("IsWalking", true) ;
            }
            else
            {
                this.Animator.SetBool("IsWalking",false);
            }
        }

        // Points player in the direction of the mouse.
        void AimAtMouse()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 mouseDirection = ((Vector2)mousePos - (Vector2)this.gameObject.transform.position).normalized;
            float mouseAngle = Vector2.SignedAngle(Vector2.right, mouseDirection);
            // Rotates player across the z axis.
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, mouseAngle);
        }

        // Charges the main battery when picking up a portable battery.
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Portable Battery")
            {
                this.Battery.SetBattery(this.Battery.GetCharge() + 10f);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.name == "Outlet")
            {
                Destroy(collision.gameObject);
                SceneManager.LoadScene(4);
            }
        }

        // Increases range when fire1 held.
        // Decreases range when not "activating" the flashlight.
        private void DoUseFlashlight()
        {
            if (Input.GetButton("Fire1"))
            {
                this.Fire1.Execute(this.gameObject);
            }
            else
            {
                this.Fire1.Standby(this.gameObject);
            }
        }

        // Battery drain varies based on flashlight usage.
        private void DoDrainBattery()
        {
            this.Battery.DrainBattery(this.Fire1.Flashlight.GetRange());
        }

        // Handles all the audio sources on the Player.
        private void PlayAudios()
        {
            PlayAudioBackground();
            PlayAudioFlashlight();
            PlayAudioFootsteps();
            PlayAudioEndgame();
        }

        // Audio Background volume is based on an exponential curve.
        // Range(init volume, max volume) = starting charge of the battery.
        // I.e. if the starting charge of the battery is 20%, then the
        // background audio will reach max volume at (20% - 20% = )0% charge.
        private void PlayAudioBackground()
        {
            if (this.Battery.GetCharge() <= this.StartingCharge &&
                this.AudioSourceBackground.volume < 1)
            {
                this.AudioSourceBackground.volume =
                    this.StartingVolume *
                    Mathf.Pow(1 + this.BackgroundAudioGrowthRate,
                              this.StartingCharge - this.Battery.GetCharge());
            }
            else if (this.Battery.GetCharge() > this.StartingCharge)
            {
                this.AudioSourceBackground.volume = this.StartingVolume;
            }
        }

        private void PlayAudioFlashlight()
        {
            if (Input.GetButtonDown("Fire1"))
                {
                    AudioSourceLight.Play();
                }
            if (Input.GetButtonUp("Fire1"))
            {
                AudioSourceLight.Stop();
            }
        }

        private void PlayAudioFootsteps()
        {
            if (this.PlayerBody.velocity.magnitude >= 2.5f &&
                !this.AudioSourceFootsteps.isPlaying)
                {
                    this.AudioSourceFootsteps.Play();
                }
            else if (this.PlayerBody.velocity.magnitude < 2.5f)
            {
                this.AudioSourceFootsteps.Stop();
            }
        }

        private void PlayAudioEndgame()
        {
            if (this.Battery.GetCharge() <= 0.0f && this.GameOver == false)
            {
                AudioSourceEndgame.Play();
                this.GameOver = true;
                SceneManager.LoadScene(3);
            }

        }
    }
}