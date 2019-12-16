using System;
using Core.MakeFuel;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day14 : Day
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reactor = new NanoReactor(InputData.Reactions);
            var oreCount = reactor.GetRequiredOreForOneFuel();

            Console.WriteLine($"Number of ores: {oreCount}");

            WritePartTitle();
            var reactor2 = new NanoReactor(InputData.Reactions);
            var fuelCount = reactor.GetUntilOutOfOre(1000000000000);

            Console.WriteLine($"Maximum fuel: {fuelCount}");
        }
    }
}