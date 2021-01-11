using System;
using Core.AirDuct;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day24 : Day2016
    {
        private AirDuctNavigator Navigator => new(FileInput);
        
        public Day24() : base(24)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var shortestPath = Navigator.Run(false);
            return new PuzzleResult(shortestPath, 502);
        }

        public override PuzzleResult RunPart2()
        {
            var shortestPath = Navigator.Run(true);
            return new PuzzleResult(shortestPath, 724);
        }
    }
}