using System;
using Core.ClockSignal;

namespace ConsoleApp.Years.Year2016
{
    public class Day25 : Day
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