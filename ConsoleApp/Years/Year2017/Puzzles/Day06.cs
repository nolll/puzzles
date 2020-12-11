using System;
using Core.MemoryReallocation;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day06 : Day2017
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            return new PuzzleResult($"Steps to repeat: {reallocator.Steps}");
        }

        public override PuzzleResult RunPart2()
        {
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            return new PuzzleResult($"Loop size: {reallocator.LoopSize}");
        }
    }
}