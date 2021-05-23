using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameObject);
    }
}
