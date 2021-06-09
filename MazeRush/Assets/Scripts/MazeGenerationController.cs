using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// TODO: Get rid of binary matrix and only use MazeCell matrix

public class MazeGenerationController : MonoBehaviour
{
    [SerializeField]
    int Rows = 5;
    [SerializeField]
    int Columns = 5;
    // Start is called before the first frame update
    [SerializeField]
    float HallWidth = 1;
    [SerializeField]
    float HallHeight = 1;
    [SerializeField]
    GameObject WallPrefab;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject BatteryPrefab;
    [SerializeField]
    GameObject GoalPrefab;
    GameObject plane;
    int[,] MazeData;

    MazeCell[,] RecursiveBacktrackingMazeGeneration()
    {
        // Generate matrix of closed cells
        var maze = new MazeCell[this.Rows, this.Columns];
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                maze[row, col] = new MazeCell(row, col);
            }
        }
        // Stack of unfinished cells
        var stack = new List<MazeCell>(); 
        // Pick a random cell
        stack.Add(maze[Random.Range(0, this.Rows), Random.Range(0, this.Columns)]);
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
        // Generate game-specific values
        // Pick a random cell to be the player's spawn
        generatedMaze[Random.Range(0, this.Rows), Random.Range(0, this.Columns)].Type = MazeCell.CellType.PlayerSpawn;
        // Each cell has a random chance to spawn a battery
        MazeCell curCell;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                curCell = generatedMaze[row, col];
                if (curCell.Type != MazeCell.CellType.PlayerSpawn && Random.Range(0, this.Rows * this.Columns - 1) == 0)
                {
                    curCell.Type = MazeCell.CellType.BatterySpawn;
                }
            }
        }
        // Pick random cell for the outlet placement
        do
        {
            curCell = generatedMaze[Random.Range(0, this.Rows), Random.Range(0, this.Columns)];
        } while (curCell.Type != MazeCell.CellType.Default);
        curCell.Type = MazeCell.CellType.Goal;
        // Result is a matrix of MazeCells
        // convert matrix of MazeCells into numeric matrix
        MazeData = new int[2 * this.Rows + 1, 2 * this.Columns + 1];
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                MazeData[1 + (2 * row), 1 + (2 * col)] = (int) generatedMaze[row, col].Type;
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
        float planeHeight = cellRows * this.HallHeight + wallRows * this.HallHeight;
        float planeWidth = cellCols * this.HallWidth + wallCols * this.HallWidth;
        plane.transform.localScale = new Vector3(planeWidth / 10f, 1, planeHeight / 10f);
        Vector2 planeTopLeft = new Vector3(this.plane.transform.position.x - (planeWidth / 2),
                                           this.plane.transform.position.y + (planeHeight / 2));

        for (int row = 0; row < MazeData.GetLength(0); row++)
        {
            for (int col = 0; col < MazeData.GetLength(1); col++)
            {
                var position = new Vector3(planeTopLeft.x + (this.HallWidth / 2) + col * this.HallWidth, 
                                            planeTopLeft.y - (this.HallHeight / 2) - row * this.HallHeight, 
                                            -1f);
                var playerPosition = new Vector3(planeTopLeft.x + (this.HallWidth / 2) + col * this.HallWidth, 
                                            planeTopLeft.y - (this.HallHeight / 2) - row * this.HallHeight, 
                                            -0.5f);
                switch (MazeData[row, col])
                {
                    case 0:
                        var wallWrapper = new GameObject("WallWrapper");
                        var wall = Instantiate(this.WallPrefab);
                        wall.transform.position = -wall.GetComponentInChildren<Renderer>().bounds.center;
                        wall.transform.SetParent(wallWrapper.transform);
                        wallWrapper.transform.position = position;
                        wallWrapper.transform.rotation = this.plane.transform.rotation;
                        var realScale = wall.GetComponentInChildren<Collider>().bounds.size;
                        wallWrapper.transform.localScale = new Vector3(this.HallWidth / realScale.x, 1 / realScale.y, this.HallHeight / realScale.z);
                        wallWrapper.transform.SetParent(this.plane.transform);
                        break;
                    case (int) MazeCell.CellType.PlayerSpawn:
                        this.Player.transform.position = playerPosition;
                        break;
                    case (int) MazeCell.CellType.BatterySpawn:
                        Instantiate(this.BatteryPrefab,
                                    position,
                                    Quaternion.identity).name = "Portable Battery";
                        break;
                    case (int) MazeCell.CellType.Goal:
                        Instantiate(this.GoalPrefab,
                                    position,
                                    Quaternion.identity).name = "Outlet";
                        break;
                }
            }
        }
    }
}
