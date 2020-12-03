using System;
using Core.SpiralMemory;

namespace ConsoleApp.Years.Year2017
{
    public class Day03 : Day2017
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var memory1 = new SpiralMemory(NumberInput, SpiralMemoryMode.RunToTarget);
            Console.WriteLine($"Steps from center: {memory1.Distance}");

            WritePartTitle();
            var memory2 = new SpiralMemory(NumberInput, SpiralMemoryMode.RunToValue);
            Console.WriteLine($"First value above input: {memory2.Value}");
        }

        private const int NumberInput = 265149;
    }
}