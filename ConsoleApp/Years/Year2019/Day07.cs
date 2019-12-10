using System;
using ConsoleApp.Inputs;
using Core.Thrust;

namespace ConsoleApp.Years.Year2019
{
    public class Day07 : Day
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new ThrustCalculator(InputData.ComputerProgramDay7);
            var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
            Console.WriteLine($"Maximum thrust: {maxThrust1}");

            WritePartTitle();
            calculator = new ThrustCalculator(InputData.ComputerProgramDay7);
            var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
            Console.WriteLine($"Maximum thrust: {maxThrust2}");
        }
    }
}