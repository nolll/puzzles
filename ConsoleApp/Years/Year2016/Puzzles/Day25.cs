using System;
using Core.ClockSignal;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day25 : Day2016
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var generator = new ClockSignalGenerator();
            return new PuzzleResult($"Lowest A: {generator.LowestA}");
        }
    }
}