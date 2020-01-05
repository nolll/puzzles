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
            var memory = new SpiralMemory(Input);
            Console.WriteLine($"Steps from center: {memory.Distance}");
        }

        private const int Input = 265149;
    }
}