using System;
using Core.DonutMaze;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day20 : Day2019
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var mazeSolver = new DonutMazeSolver(FileInput);
            Console.WriteLine($"Shortest distance from AA to ZZ: {mazeSolver.ShortestStepCount}");

            WritePartTitle();
            var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(FileInput);
            Console.WriteLine($"Shortest distance from AA to ZZ: {recursiveDonutMazeSolver.ShortestStepCount}");
        }
    }
}