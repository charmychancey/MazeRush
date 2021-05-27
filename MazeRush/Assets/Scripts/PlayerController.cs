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

        private MovePlayer MovePlayer;
        private UseFlashlight Fire1;
        private IBattery Battery;
        [SerializeField] public Text BatteryLevelDisplay;

        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UseFlashlight>();
            this.Battery = new DefaultBattery();
        }

        // Update is called once per frame
        void Update()
        {
            DoPlayerMovement();
            DoUseFlashlight();
            DoDrainBattery();
            this.BatteryLevelDisplay.text = this.Battery.GetCharge().ToString("F2");
        }

        private void DoPlayerMovement()
        {
            if (Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0)
            {
                this.MovePlayer.Execute(this.gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Portable Battery")
            {
                this.Battery.SetBattery(this.Battery.GetCharge() + 10f);
                Destroy(collision.gameObject);
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

        private void DoDrainBattery()
        {
            this.Battery.DrainBattery(this.Fire1.Flashlight.GetRange());
        }
    }
}