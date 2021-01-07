using System;
using Core.DonutMaze;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day20 : Day2019
    {
        public override string Comment => "Donut Maze";
        public override bool IsSlow => true;

        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var mazeSolver = new DonutMazeSolver(FileInput);
            return new PuzzleResult(mazeSolver.ShortestStepCount, 462);
        }

        public override PuzzleResult RunPart2()
        {
            var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(FileInput);
            return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, 5288);
        }
    }
}