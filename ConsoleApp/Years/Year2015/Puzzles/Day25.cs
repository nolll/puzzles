using System;
using Core.WeatherMachine;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day25 : Day2015
    {
        public Day25() : base(25)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var codeFinder = new WeatherMachineCodeFinder();
            var code = codeFinder.FindCodeAt(TargetX, TargetY);
            Console.WriteLine($"Weather Machine code: {code}");
        }

        private const int TargetY = 2978;
        private const int TargetX = 3083;
    }
}