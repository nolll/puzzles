using System;
using Core.SpiralMemory;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day03 : Day2017
    {
        public Day03() : base(3)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var memory1 = new SpiralMemory(Input, SpiralMemoryMode.RunToTarget);
            return new PuzzleResult($"Steps from center: {memory1.Distance}");
        }

        public override PuzzleResult RunPart2()
        {
            var memory2 = new SpiralMemory(Input, SpiralMemoryMode.RunToValue);
            return new PuzzleResult($"First value above input: {memory2.Value}");
        }

        private const int Input = 265149;
    }
}