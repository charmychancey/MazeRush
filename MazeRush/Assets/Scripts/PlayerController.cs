using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeRush;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Phone;

    private IPlayerCommand MovePlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.MovePlayer = ScriptableObject.CreateInstance<MovePlayer>();
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
}
