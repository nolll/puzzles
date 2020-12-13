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
            return new PuzzleResult(reallocator.Steps, 6681);
        }

        public override PuzzleResult RunPart2()
        {
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            return new PuzzleResult(reallocator.LoopSize, 2392);
        }
    }
}