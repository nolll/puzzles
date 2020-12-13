using System;
using Core.HexGrid;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day11 : Day2017
    {
        public Day11() : base(11)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var navigator = new HexGridNavigator(FileInput);
            return new PuzzleResult(navigator.EndDistance, 808);
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new HexGridNavigator(FileInput);
            return new PuzzleResult(navigator.MaxDistance, 1556);
        }
    }
}