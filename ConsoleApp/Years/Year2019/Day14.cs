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
            var oreCount = reactor.GetRequiredOre();

            Console.WriteLine($"Number of ores: {oreCount}");
        }
    }
}