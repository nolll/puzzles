using System;
using Core.SpiralMemory;

namespace ConsoleApp.Years.Year2017
{
    public class Day03 : Day
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var memory1 = new SpiralMemory(Input, SpiralMemoryMode.RunToTarget);
            Console.WriteLine($"Steps from center: {memory1.Distance}");

            WritePartTitle();
            var memory2 = new SpiralMemory(Input, SpiralMemoryMode.RunToValue);
            Console.WriteLine($"First value above input: {memory2.Value}");
        }

        private const int Input = 265149;
    }
}