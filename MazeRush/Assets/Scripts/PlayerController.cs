using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeRush;

namespace MazeRush
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject Phone;

        private IPlayerCommand MovePlayer;
        private IPlayerCommand Fire1;
        private LightController Flashlight;

        // Start is called before the first frame update
        void Start()
        {
            this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
            this.Fire1 = ScriptableObject.CreateInstance<UsePrimaryItemA>();
        }

        // Update is called once per frame
        void Update()
        {
            DoPlayerMovement();
        }

        private void DoPlayerMovement()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                this.MovePlayer.Execute(this.gameObject);
            }
        }

        private void DoUsePrimaryItemA()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                this.Fire1.Execute(this.gameObject);
            }
        }
    }
}