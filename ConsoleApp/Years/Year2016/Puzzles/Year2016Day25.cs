using System;
using Core.ClockSignal;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Year2016Day25 : Year2016Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var generator = new ClockSignalGenerator();
            return new PuzzleResult(generator.LowestA, 198);
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}