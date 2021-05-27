using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    public class UseFlashlight : ScriptableObject, IPlayerCommand
    {
        private float GainRate = 10.0f;
        private float LossRate = 20.0f;
        public LightController Flashlight;
        public void Execute(GameObject player)
        {
            this.Flashlight =
                player.GetComponentInChildren<LightController>();
            if (this.Flashlight == null)
            {
                Debug.Log("Player command error: Fire1");
            }

            this.Flashlight.SetRange(
                this.Flashlight.GetRange() + (this.GainRate * Time.deltaTime));
            Debug.Log("gain rate: " + this.GainRate);
        }

        public void Standby(GameObject player)
        {
            this.Flashlight =
                player.GetComponentInChildren<LightController>();
            if (this.Flashlight == null)
            {
                Debug.Log("Player command error: Fire1");
            }

            this.Flashlight.SetRange(
                this.Flashlight.GetRange() - (this.LossRate * Time.deltaTime));
        }
    }
}
