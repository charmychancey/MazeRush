using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerationController : MonoBehaviour
{
    // Start is called before the first frame update
    public float HallWidth = 1;
    public float HallHeight = 1;
    public float VWallHeight = 1;
    public float VWallWidth = 1;
    public float HWallHeight = 1;
    public float HWallWidth = 1;
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
        // TODO: VWallHeight == HWallHeight == HallHeight. Get rid of the extra variables
        // TODO: Get rid of the scaling and just copy/paste walls with scale 1
        float cellRows = (MazeData.GetLength(0) - 1) / 2;
        float cellCols = (MazeData.GetLength(1) - 1) / 2;
        float wallRows = cellRows + 1;
        float wallCols = cellCols + 1;
        float planeHeight = cellRows * this.HallHeight + wallRows * this.HWallHeight;
        float planeWidth = cellCols * this.HallWidth + wallCols * this.VWallWidth;
        plane.transform.localScale = new Vector3(planeWidth / 10, 1, planeHeight / 10);
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
                        wallPosition = new Vector3(planeTopLeft.x + (this.VWallWidth / 2) + (col/2) * (this.HWallWidth + this.HallWidth), 
                                                   planeTopLeft.y - (this.HWallHeight / 2) - (row/2) * (this.VWallHeight + this.HallHeight), 
                                                   -1f);
                        wallScale = new Vector3(this.VWallWidth, this.HWallHeight, 1);
                    }
                    else
                    {
                        // horizontal wall
                        wallPosition = new Vector3(planeTopLeft.x + (this.VWallWidth) + (this.HWallWidth / 2) + (col/2) * (this.HWallWidth + this.HallWidth), 
                                                   planeTopLeft.y - (this.HWallHeight / 2) - (row/2) * (this.VWallHeight + this.HallHeight), 
                                                   -1f);
                        wallScale = new Vector3(this.HWallWidth, this.HWallHeight, 1);
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
                        wallPosition = new Vector3(planeTopLeft.x + (this.VWallWidth / 2) + (col/2) * (this.VWallWidth + this.HallWidth), 
                                                   planeTopLeft.y - (this.HWallHeight) - (this.VWallHeight / 2) - (row/2) * (this.VWallHeight + this.HallHeight), 
                                                   -1f);
                        wallScale = new Vector3(this.VWallWidth, this.VWallHeight, 1    );
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
