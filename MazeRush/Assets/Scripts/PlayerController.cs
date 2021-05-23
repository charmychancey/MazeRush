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

        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UseFlashlight>();
        }

        // Update is called once per frame
        void Update()
        {
            DoPlayerMovement();
            DoUseFlashlight();
        }

        private void DoPlayerMovement()
        {
            if (Input.GetAxis("Horizontal") != 0 ||
                Input.GetAxis("Vertical") != 0)
            {
                this.MovePlayer.Execute(this.gameObject);
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