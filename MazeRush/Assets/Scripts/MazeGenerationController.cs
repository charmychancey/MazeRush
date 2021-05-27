using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMeshGenerationController : MonoBehaviour
{
    // Start is called before the first frame update
    public float HallWidth;
    public float HallHeight;
    // public float;
    int[,] MazeData;

    void GenerateRandomMaze()
    {
        MazeData = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 1, 1, 0},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 1, 1, 1, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }


    void Start()
    {
        GenerateRandomMaze();
        GenerateMesh();

    }

    void GenerateMesh()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
