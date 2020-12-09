using System;
using Core.MakeFuel;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day14 : Day2019
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var reactor = new NanoReactor(FileInput);
            reactor.Run();
            var oreForOneFuel = reactor.RequiredOreForOneFuel;

            Console.WriteLine($"Number of ores for one fuel: {oreForOneFuel}");

            WritePartTitle();
            var fuelCount = reactor.FuelFromOneTrillionOre;

            Console.WriteLine($"Maximum fuel: {fuelCount}");
        }
    }
}