using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLockedCameraController : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    float CameraDistance;

    private void Start() 
    {
        CameraDistance = this.transform.position.z;
    }

    private void LateUpdate() 
    {
        Vector2 playerPosition = Player.transform.position;
        this.transform.position = new Vector3(playerPosition.x, playerPosition.y, this.CameraDistance);
    }
}
