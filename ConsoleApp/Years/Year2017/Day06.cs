using System;
using Core.MemoryReallocation;

namespace ConsoleApp.Years.Year2017
{
    public class Day06 : Day
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reallocator = new MemoryReallocator(Input);
            reallocator.Run();
            Console.WriteLine($"Steps to repeat: {reallocator.Steps}");

            WritePartTitle();
            Console.WriteLine($"Loop size: {reallocator.LoopSize}");
        }

        private const string Input = "4,1,15,12,0,9,9,5,5,8,7,3,14,5,12,3";
    }
}