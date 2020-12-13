using System;
using Core.CpuInstructions;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day08 : Day2017
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new CpuInstructionCalculator(FileInput);
            return new PuzzleResult(calculator.LargestValueAtEnd, 6012);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new CpuInstructionCalculator(FileInput);
            return new PuzzleResult(calculator.LargestValueEver, 6369);
        }
    }
}