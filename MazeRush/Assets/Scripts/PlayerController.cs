using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MazeRush;

namespace MazeRush
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject Phone;
        [SerializeField] public Animator Animator;
        [SerializeField] public Text BatteryLevelDisplay;

        private MovePlayer MovePlayer;
        private UseFlashlight Fire1;
        private IBattery Battery;
        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthbar;
        //public AudioSource audiosource;
        public AudioSource audiosourcelight;

        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UseFlashlight>();
            this.Battery = new DefaultBattery();
            currentHealth=maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            this.Animator = this.gameObject.GetComponentInChildren<Animator>();
            Debug.Log(this.Animator);
        }

        // Update is called once per frame
        void Update()
        {
            AimAtMouse();
            playaudio();
            DoUseFlashlight();
            DoDrainBattery();
            this.BatteryLevelDisplay.text = this.Battery.GetCharge().ToString("F2");
            // if (Input.GetButton("Fire1"))
            // {
            //     TakeDamage(1);
            // }
            TakeDamage();
        }

        void TakeDamage()
        {
            // currentHealth -= damage;
            healthbar.SetHealth((int)this.Battery.GetCharge());
        }

        private void FixedUpdate() {
            DoPlayerMovement();
        }

        private void playaudio()
        {
            if (Input.GetButtonDown("Fire1"))
                {
                    audiosourcelight.Play();
                    //audiosource.Play();

                }
            if (Input.GetButtonUp("Fire1"))
            {
                audiosourcelight.Stop();
            }
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

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Portable Battery")
            {
                this.Battery.SetBattery(this.Battery.GetCharge() + 10f);
                Destroy(collision.gameObject);
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
    }
}