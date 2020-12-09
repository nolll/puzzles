using System;
using Core.DominoBridge;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day24 : Day2017
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var builder1 = new BridgeBuilder(FileInput, false);
            var bridge1 = builder1.Build();
            Console.WriteLine($"Strength of strongest bridge: {bridge1.Strength}.");

            WritePartTitle();
            var builder2 = new BridgeBuilder(FileInput, true);
            var bridge2 = builder2.Build();
            Console.WriteLine($"Strength of longest bridge: {bridge2.Strength}.");
        }
    }
}