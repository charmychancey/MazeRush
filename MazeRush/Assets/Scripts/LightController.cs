using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
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
            this.Light.range = this.Range;
        }

        public float GetRange()
        {
            return this.Range;
        }

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
    }
}