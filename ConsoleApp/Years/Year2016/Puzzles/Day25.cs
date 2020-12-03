using System;
using Core.ClockSignal;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day25 : Day2016
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var generator = new ClockSignalGenerator();
            Console.WriteLine($"Lowest A: {generator.LowestA}");
        }
    }
}