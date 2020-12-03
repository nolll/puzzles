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
            var reallocator = new MemoryReallocator(LegacyInput);
            reallocator.Run();
            Console.WriteLine($"Steps to repeat: {reallocator.Steps}");

            WritePartTitle();
            Console.WriteLine($"Loop size: {reallocator.LoopSize}");
        }

        protected override string LegacyInput => "4,1,15,12,0,9,9,5,5,8,7,3,14,5,12,3";
    }
}