using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    // Flashlight controller for main player object.
    public class LightController : MonoBehaviour
    {
        [SerializeField] private float MaxRange = 60.0f;
        [SerializeField] private float MinRange = 15.0f;
        private float Range;
        private Light Light;
        void Start()
        {
            this.Light = this.gameObject.GetComponent<Light>();
            this.Range = this.Light.range;
        }

        void Update()
        {
            this.AimAtMouse();
            this.Light.range = this.Range;
        }

        public float GetRange()
        {
            return this.Range;
        }

        // Sets the range of flashlight,
        // while controlling for max and min ranges.
        public void SetRange(float range)
        {
            if (range > this.MaxRange)
            {
                this.Range = this.MaxRange;
            }
            else if (range < this.MinRange)
            {
                this.Range = this.MinRange;
            }
            else
            {
                this.Range = range;
            }
        }

        void AimAtMouse()
        {
            // Points light in the direction of the mouse.
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 mouseDirection = ((Vector2)mousePos - (Vector2)this.gameObject.transform.position).normalized;
            float mouseAngle = -Vector2.SignedAngle(Vector2.right, mouseDirection);
            // Rotates light across the x axis.
            // Sets y to 90 to offset the plane dimension.
            this.gameObject.transform.eulerAngles = new Vector3(mouseAngle, 90, 0);
        }
    }
}