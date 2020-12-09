using System;
using Core.MemoryReallocation;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day06 : Day2017
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reallocator = new MemoryReallocator(FileInput);
            reallocator.Run();
            Console.WriteLine($"Steps to repeat: {reallocator.Steps}");

            WritePartTitle();
            Console.WriteLine($"Loop size: {reallocator.LoopSize}");
        }
    }
}