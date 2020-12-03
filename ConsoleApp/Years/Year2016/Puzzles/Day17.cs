using System;
using Core.HashedDoors;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day17 : Day2016
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var maze = new LockedDoorMaze();
            maze.FindPaths(LegacyInput);
            Console.WriteLine($"Shortest path: {maze.ShortestPath}");

            WritePartTitle();
            Console.WriteLine($"Longest path length: {maze.LongestPath.Length}");
        }

        protected override string LegacyInput => "yjjvjgan";
    }
}