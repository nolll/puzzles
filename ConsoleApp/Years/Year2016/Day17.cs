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
            var shortestPath = maze.FindShortestPath(Input);
            Console.WriteLine($"Shortest path: {shortestPath}");
        }

        private const string Input = "yjjvjgan";
    }
}