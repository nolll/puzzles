using System;
using ConsoleApp.Inputs;
using Core.ModuleMass;

namespace ConsoleApp.Days
{
    public class Day01 : Day
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var massCalculator = new MassCalculator(InputData.ModulesMasses);
            Console.WriteLine($"Required fuel: {massCalculator.MassFuel}");

            WritePartTitle();
            Console.WriteLine($"Required total fuel: {massCalculator.TotalFuel}");
        }
    }
}