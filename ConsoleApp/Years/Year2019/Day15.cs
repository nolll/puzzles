using System;
using Core.OxygenSystem;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day15 : Day
    {
        public Day15() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var droid = new RepairDroid(InputData.ComputerProgramDay13);
            var result1 = droid.Run();

            Console.WriteLine($"Steps to find oxygen system: {result1}");
        }
    }
}