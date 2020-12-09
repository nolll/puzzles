using System;
using Core.Thrust;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day07 : Day2019
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new ThrustCalculator(FileInput);
            var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
            Console.WriteLine($"Maximum thrust: {maxThrust1}");

            WritePartTitle();
            calculator = new ThrustCalculator(FileInput);
            var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
            Console.WriteLine($"Maximum thrust: {maxThrust2}");
        }
    }
}