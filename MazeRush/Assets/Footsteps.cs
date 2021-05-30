using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeRush;

namespace MazeRush
{
    public class Footsteps : MonoBehaviour
{
    MovePlayer pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = ScriptableObject.CreateInstance<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc != null && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
}

}
