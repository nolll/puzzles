using System;
using Core.DonutMaze;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day20 : Day2019
    {
        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var mazeSolver = new DonutMazeSolver(FileInput);
            return new PuzzleResult($"Shortest distance from AA to ZZ: {mazeSolver.ShortestStepCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(FileInput);
            return new PuzzleResult($"Shortest distance from AA to ZZ: {recursiveDonutMazeSolver.ShortestStepCount}");
        }
    }
}