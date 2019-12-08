using System;
using ConsoleApp.Inputs;
using Core.Thrust;

namespace ConsoleApp.Days
{
    public class Day07 : Day
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator1 = new ThrustCalculator(InputData.ComputerProgramDay7);
            var maxThrust1 = calculator1.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
            Console.WriteLine($"Maximum thrust: {maxThrust1}");

            WritePartTitle();
            var calculator2 = new ThrustCalculator2(InputData.ComputerProgramDay7);
            var maxThrust2 = calculator2.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
            Console.WriteLine($"Maximum thrust: {maxThrust2}");
        }
    }
}