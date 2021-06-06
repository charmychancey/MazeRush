using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// TODO: Get rid of binary matrix and only use MazeCell matrix

public class MazeGenerationController : MonoBehaviour
{
    public Vector2Int MazeDimensions = new Vector2Int(3, 3);
    // Start is called before the first frame update
    public int HallWidth = 1;
    public int HallHeight = 1;
    public GameObject WallPrefab;
    GameObject plane;
    int[,] MazeData;

    MazeCell[,] RecursiveBacktrackingMazeGeneration()
    {
        // Generate matrix of closed cells
        var maze = new MazeCell[this.MazeDimensions.x, this.MazeDimensions.y];
        for (int row = 0; row < this.MazeDimensions.x; row++)
        {
            for (int col = 0; col < this.MazeDimensions.y; col++)
            {
                maze[row, col] = new MazeCell(row, col);
            }
        }
        // Stack of unfinished cells
        var stack = new List<MazeCell>(); 
        // Pick a random cell
        stack.Add(maze[Random.Range(0, this.MazeDimensions.x), Random.Range(0, this.MazeDimensions.y)]);
        stack.Last().Visited = true;
        while(stack.Any())
        {
            // Get unvisited neighbors
            var neighbors = stack.Last().GetUnvisitedNeighbors(maze);
            if (neighbors.Any())
            {
                // Pick one at random
                var nextCell = neighbors[Random.Range(0, neighbors.Count())];
                // Open wall between cells
                stack.Last().OpenWallTo(nextCell);
                // Add cell to stack
                stack.Add(nextCell);
                // Mark the new cell as visited
                nextCell.Visited = true;
            }
            else
            {
                stack.RemoveAt(stack.Count() - 1);
            }
        }
        return maze;
    }

    void GenerateRandomMaze()
    {
        // Generate maze with algorithm
        var generatedMaze = this.RecursiveBacktrackingMazeGeneration();
        // Result is a matrix of MazeCells
        // convert matrix of MazeCells into binary matrix
        MazeData = new int[2 * generatedMaze.GetLength(0) + 1, 2 * generatedMaze.GetLength(1) + 1];
        for (int row = 0; row < generatedMaze.GetLength(0); row++)
        {
            for (int col = 0; col < generatedMaze.GetLength(1); col++)
            {
                MazeData[1 + (2 * row), 1 + (2 * col)] = 1;
                if (generatedMaze[row, col].Up)
                {
                    MazeData[(2 * row), 1 + (2 * col)] = 1;
                }
                if (generatedMaze[row, col].Left)
                {
                    MazeData[1 + (2 * row), (2 * col)] = 1;
                }
            }
        }
        // MazeData = new int[,]
        // {
        //     {0, 0, 0, 0, 0, 0, 0},
        //     {0, 1, 1, 1, 1, 1, 0},
        //     {0, 1, 0, 0, 0, 1, 0},
        //     {0, 1, 0, 1, 1, 1, 0},
        //     {0, 1, 0, 0, 0, 0, 0},
        //     {0, 1, 1, 1, 0, 1, 0},
        //     {0, 0, 0, 0, 0, 0, 0}
        // };
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
