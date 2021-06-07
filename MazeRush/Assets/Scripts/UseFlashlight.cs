using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    // Using the flashlight expands its range.
    public class UseFlashlight : ScriptableObject, IPlayerCommand
    {
        private float GainRate = 10.0f;
        private float LossRate = 20.0f;
        public LightController Flashlight;

        // Increases range.
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
        }

        // Decreases range.
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
