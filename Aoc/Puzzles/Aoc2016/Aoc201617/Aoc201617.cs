﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201617;

[Name("Two Steps Forward")]
public class Aoc201617(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(input);
        return new PuzzleResult(maze.ShortestPath, "145f734762c2ff3fc7d2661d011be656");
    }

    protected override PuzzleResult RunPart2()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(input);
        return new PuzzleResult(maze.LongestPath?.Length, "0926372f3b51236a2e58ce27bc97d696");
    }
}