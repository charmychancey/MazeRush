using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeRush;

namespace MazeRush
{
    public class ExpositionTrigger : MonoBehaviour
    {
        public Exposition exposition;

        public void TriggerExposition()
        {
            FindObjectOfType<ExpositionController>().StartExposition(exposition);
        }
    }
}
