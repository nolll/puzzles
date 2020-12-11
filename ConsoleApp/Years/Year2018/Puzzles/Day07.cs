using System;
using Core.SleighAssembly;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day07 : Day2018
    {
        public Day07() : base(7)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var assembler1 = new SleighAssembler(FileInput, 1, 0);
            var result1 = assembler1.Assemble();
            return new PuzzleResult($"Sleigh assembly order: {result1.Order}");
        }

        public override PuzzleResult RunPart2()
        {
            var assembler2 = new SleighAssembler(FileInput, 5, 60);
            var result2 = assembler2.Assemble();
            return new PuzzleResult($"Time spent: {result2.Time}s");
        }
    }
}