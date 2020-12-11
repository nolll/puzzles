using System;
using Core.ChronalCoordinates;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day06 : Day2018
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var finder = new LargestAreaFinder(FileInput);
            var size = finder.GetSizeOfLargestArea();
            return new PuzzleResult($"Size of largest area: {size}");
        }

        public override PuzzleResult RunPart2()
        {
            var finder = new LargestAreaFinder(FileInput);
            var size = finder.GetSizeOfCentralArea(10000);
            return new PuzzleResult($"Size of central area: {size}");
        }
    }
}