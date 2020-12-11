using System;
using Core.CubicleMaze;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day13 : Day2016
    {
        public Day13() : base(13)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var maze = new Maze(50, 50, Input);
            var stepCount = maze.StepCountToTarget(31, 39);
            return new PuzzleResult($"Required number of steps: {stepCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var maze = new Maze(75, 75, Input);
            var locationCount = maze.LocationCountAfter(50);
            return new PuzzleResult($"Number of location: {locationCount}");
        }

        private const int Input = 1362;
    }
}