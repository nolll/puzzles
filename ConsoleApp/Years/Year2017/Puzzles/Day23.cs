using System;
using Core.CoprocessorConflagration;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day23 : Day2017
    {
        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var processor1 = new CoProcessor(FileInput);
            processor1.Run();
            return new PuzzleResult(processor1.MulCount, 4225);
        }

        public override PuzzleResult RunPart2()
        {
            var processor2 = new OptimizedCoProcessor();
            processor2.Run();
            return new PuzzleResult(processor2.H, 905);
        }
    }
}