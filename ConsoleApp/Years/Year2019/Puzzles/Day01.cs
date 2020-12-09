using System;
using Core.ModuleMass;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day01 : Day2019
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var massCalculator = new MassCalculator(FileInput);
            Console.WriteLine($"Required fuel: {massCalculator.MassFuel}");

            WritePartTitle();
            Console.WriteLine($"Required total fuel: {massCalculator.TotalFuel}");
        }
    }
}