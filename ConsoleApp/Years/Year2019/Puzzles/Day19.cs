using System;
using Core.TractorBeam;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day19 : Day2019
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var tbc = new TractorBeamComputer1(FileInput, 50, 50);
            var result = tbc.GetPullCount();

            return new PuzzleResult($"Number of pulled coordinates: {result}");
        }

        public override PuzzleResult RunPart2()
        {
            var tbc = new TractorBeamComputer1(FileInput, 50, 50);
            var result = tbc.GetPullCount();

            return new PuzzleResult($"Number of pulled coordinates: {result}");
        }
    }
}