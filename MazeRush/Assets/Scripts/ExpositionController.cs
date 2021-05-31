using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MazeRush
{
    // Exposition system was adapted from the tutorial at:
    // https://www.youtube.com/watch?v=_nRzoTzeyxU&t=613s
    public class ExpositionController : MonoBehaviour
    {
        private Queue<string> Sentences;

        public Text ExpositionText;
        public ExpositionTrigger ExpositionTrigger;

        void Start()
        {
            this.Sentences = new Queue<string>();
            this.ExpositionTrigger.TriggerExposition();
        }

        public void StartExposition(Exposition exposition)
        {
            this.Sentences.Clear();

            foreach (string sentence in exposition.Sentences)
            {
                this.Sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            Debug.Log("'Next' button clicked...");
            if (this.Sentences.Count == 0)
            {
                EndExposition();
                return;
            }

            string sentence = this.Sentences.Dequeue();
            this.ExpositionText.text = sentence;
        }

        void EndExposition()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

}