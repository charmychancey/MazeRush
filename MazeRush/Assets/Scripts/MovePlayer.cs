using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    public class MovePlayer : ScriptableObject, IPlayerCommand
    {
        private readonly float Speed = 5.0f;
        public void Execute(GameObject player)
        {
            var rigidBody = player.GetComponent<Rigidbody>();

            if (rigidBody != null)
            {
                rigidBody.AddForce(Input.GetAxisRaw("Horizontal") * this.Speed, Input.GetAxisRaw("Vertical") * this.Speed, 0, ForceMode.Impulse);
            }
        }
    }
}
