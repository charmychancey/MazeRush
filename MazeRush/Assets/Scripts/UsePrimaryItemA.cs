using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    public class UsePrimaryItemA : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject player)
        {
            var x = Time.deltaTime;
        }
    }
}
