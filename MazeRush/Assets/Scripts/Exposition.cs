using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeRush
{
    [System.Serializable]
    public class Exposition
    {
        [TextArea(3, 10)]
        public string[] Sentences;
    }

}