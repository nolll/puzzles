using System;
using Core.HashedDoors;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day17 : Day2016
    {
        public Day17() : base(17)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var maze = new LockedDoorMaze();
            maze.FindPaths(Input);
            return new PuzzleResult($"Shortest path: {maze.ShortestPath}");
        }

        public override PuzzleResult RunPart2()
        {
            var maze = new LockedDoorMaze();
            return new PuzzleResult($"Longest path length: {maze.LongestPath.Length}");
        }

        private const string Input = "yjjvjgan";
    }
}