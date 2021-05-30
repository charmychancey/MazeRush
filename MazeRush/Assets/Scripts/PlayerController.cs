using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeRush;

namespace MazeRush
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject Phone;

        private MovePlayer MovePlayer;
        private UseFlashlight Fire1;
        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthbar;
        //public AudioSource audiosource;
        public AudioSource audiosourcelight;
        [SerializeField] public Animator Animator;


        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UseFlashlight>();
            currentHealth=maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            this.Animator = this.gameObject.GetComponentInChildren<Animator>();
            Debug.Log(this.Animator);
        }

        // Update is called once per frame
        void Update()
        {
            playaudio();
            DoUseFlashlight();
            if (Input.GetButton("Fire1"))
            {
                TakeDamage(1);
            }
        }
        void TakeDamage(int damage)
        {
            currentHealth -= damage ; 
            healthbar.SetHealth(currentHealth);
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
    }
}