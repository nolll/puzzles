using System;
using Core.EasterbunnyHq;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day01 : Day2016
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calc = new EasterbunnyDistanceCalculator();
            calc.Go(FileInput);
            Console.WriteLine($"Distance to target: {calc.DistanceToTarget}");

            WritePartTitle();
            Console.WriteLine($"Distance to first repeated address: {calc.DistanceToFirstRepeat}");
        }
    }
}