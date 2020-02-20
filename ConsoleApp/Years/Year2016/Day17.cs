using System;
using Core.HashedDoors;

namespace ConsoleApp.Years.Year2016
{
    public class Day17 : Day
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var maze = new LockedDoorMaze();
            maze.FindPaths(Input);
            Console.WriteLine($"Shortest path: {maze.ShortestPath}");

            WritePartTitle();
            Console.WriteLine($"Longest path length: {maze.LongestPath.Length}");
        }

        private const string Input = "yjjvjgan";
    }
}