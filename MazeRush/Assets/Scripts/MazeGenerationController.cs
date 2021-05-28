using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerationController : MonoBehaviour
{
    // Start is called before the first frame update
    public int HallWidth = 1;
    public int HallHeight = 1;
    public GameObject WallPrefab;
    GameObject plane;
    int[,] MazeData;

    void GenerateRandomMaze()
    {
        MazeData = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 1, 1, 0},
            {0, 1, 0, 0, 0, 1, 0},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 1, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 0, 1, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }


    void Start()
    {
        plane = this.gameObject;
        GenerateRandomMaze();
        GenerateMesh();

    }

    void GenerateMesh()
    {
        // Rescale plane to proper size
        // Plane is scaled as 10x10
        // TODO: HallHeight == HallHeight == HallHeight. Get rid of the extra variables
        // TODO: Get rid of the scaling and just copy/paste walls with scale 1
        int cellRows = (MazeData.GetLength(0) - 1) / 2;
        int cellCols = (MazeData.GetLength(1) - 1) / 2;
        int wallRows = cellRows + 1;
        int wallCols = cellCols + 1;
        int planeHeight = cellRows * this.HallHeight + wallRows * this.HallHeight;
        int planeWidth = cellCols * this.HallWidth + wallCols * this.HallWidth;
        plane.transform.localScale = new Vector3(planeWidth / 10f, 1, planeHeight / 10f);
        Vector2 planeTopLeft = new Vector3(this.plane.transform.position.x - (planeWidth / 2),
                                           this.plane.transform.position.y + (planeHeight / 2));

        for (int row = 0; row < MazeData.GetLength(0); row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < MazeData.GetLength(1); col++)
                {
                    Vector3 wallPosition;
                    Vector3 wallScale;
                    if (col % 2 == 0)
                    {
                        // corner wall
                        wallPosition = new Vector3(planeTopLeft.x + (this.HallWidth / 2) + col * this.HallWidth, 
                                                   planeTopLeft.y - (this.HallHeight / 2) - row * this.HallHeight, 
                                                   -1f);
                        wallScale = new Vector3(this.HallWidth, this.HallHeight, 1);
                    }
                    else
                    {
                        // horizontal wall
                        wallPosition = new Vector3(planeTopLeft.x + (this.HallWidth) + (this.HallWidth / 2) + (col - 1) * this.HallWidth, 
                                                   planeTopLeft.y - (this.HallHeight / 2) - row * this.HallHeight, 
                                                   -1f);
                        wallScale = new Vector3(this.HallWidth, this.HallHeight, 1);
                    }

                    if (MazeData[row, col] == 0)
                    {
                        Instantiate(this.WallPrefab, 
                                    wallPosition, 
                                    Quaternion.identity).transform.localScale = wallScale;
                    }
                }
            }
            else
            {
                for (int col = 0; col < MazeData.GetLength(1); col++)
                {
                    Vector3 wallPosition;
                    Vector3 wallScale;
                    if (col % 2 == 0)
                    {
                        // vertical wall
                        wallPosition = new Vector3(planeTopLeft.x + (this.HallWidth / 2) + col * this.HallWidth, 
                                                   planeTopLeft.y - (this.HallHeight) - (this.HallHeight / 2) - (row - 1) * this.HallHeight, 
                                                   -1f);
                        wallScale = new Vector3(this.HallWidth, this.HallHeight, 1);
                        if (MazeData[row, col] == 0)
                        {
                            Instantiate(this.WallPrefab, 
                                        wallPosition, 
                                        Quaternion.identity).transform.localScale = wallScale;
                        }
                                                   
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
