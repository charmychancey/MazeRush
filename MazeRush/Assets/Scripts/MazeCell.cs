using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MazeCell
{
    int row;
    int col;
    public bool Up { get; set; } = false;
    public bool Down { get; set; } = false;
    public bool Left { get; set; } = false;
    public bool Right { get; set; } = false;
    public bool Visited { get; set; } = false;
    public CellType Type { get; set; } = CellType.Default;

    public MazeCell(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public enum CellType
    {
        Default = 1,
        PlayerSpawn = 2,
        BatterySpawn = 3,
        Goal = 4
    }

    enum Direction
    {
        Up,
        Down,
        Right,
        Left,
    }
    Direction GetDirectionTo(MazeCell other)
    {
        if (other.row == this.row + 1 && other.col == this.col)
        {
            return Direction.Down;
        }
        else if (other.row == this.row && other.col == this.col + 1)
        {
            return Direction.Right;
        }
        else if (other.row == this.row - 1 && other.col == this.col)
        {
            return Direction.Up;
        }
        else if (other.row == this.row && other.col == this.col - 1)
        {
            return Direction.Left;
        }
        else
        {
            throw new ArgumentException("Cells are not adjacent to each other.");
        }
    }
    public void OpenWallTo(MazeCell other)
    {
        switch (this.GetDirectionTo(other))
        {
            case Direction.Up:
                this.Up = true;
                other.Down = true;
                break;
            case Direction.Down:
                this.Down = true;
                other.Up = true;
                break;
            case Direction.Right:
                this.Right = true;
                other.Left = true;
                break;
            case Direction.Left:
                this.Left = true;
                other.Right = true;
                break;
        }
    }

    public List<MazeCell> GetUnvisitedNeighbors(MazeCell[,] maze)
    {
        var output = new List<MazeCell>();
        if (this.row > 0) 
        {
            output.Add(maze[this.row - 1, this.col]);
        }
        if (this.col > 0)
        {
            output.Add(maze[this.row, this.col - 1]);
        }
        if (this.row < maze.GetLength(0) - 1) 
        {
            output.Add(maze[this.row + 1, this.col]);
        }
        if (this.col < maze.GetLength(1) - 1) 
        {
            output.Add(maze[this.row, this.col + 1]);
        }
        return output.FindAll(cell => cell.Visited == false);
    }

    static Direction GetDirectionFromTo((int, int) start, (int, int) end)
    {
        if (end.Item1 == start.Item1 + 1 && end.Item2 == start.Item2)
        {
            return Direction.Down;
        }
        else if (end.Item1 == start.Item1 && end.Item2 == start.Item2 + 1)
        {
            return Direction.Right;
        }
        else if (end.Item1 == start.Item1 - 1 && end.Item2 == start.Item2)
        {
            return Direction.Up;
        }
        else if (end.Item1 == start.Item1 && end.Item2 == start.Item2 - 1)
        {
            return Direction.Left;
        }
        else
        {
            throw new ArgumentException("Start and ending indices are not adjacent to each other.");
        }
    }
    public static void OpenWallBetween(MazeCell[,] maze, (int, int) startIndex, (int, int) endIndex)
    {
        var startCell = maze[startIndex.Item1, startIndex.Item2];
        var endCell = maze[endIndex.Item1, endIndex.Item2];
        switch (MazeCell.GetDirectionFromTo(startIndex, endIndex))
        {
            case Direction.Up:
                startCell.Up = true;
                endCell.Down = true;
                break;
            case Direction.Down:
                startCell.Down = true;
                endCell.Up = true;
                break;
            case Direction.Right:
                startCell.Right = true;
                endCell.Left = true;
                break;
            case Direction.Left:
                startCell.Left = true;
                endCell.Right = true;
                break;
        }
    }
}
