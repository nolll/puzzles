using System;
using Core.FourDimensionalAdventure;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day25 : Day2018
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var finder = new ConstellationFinder(FileInput);
            var constellationCount = finder.Find();
            return new PuzzleResult($"Constellation count: {constellationCount}");
        }
    }
}