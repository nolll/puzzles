using System;
using Core.DuelingGenerators;

namespace ConsoleApp.Years.Year2017
{
    public class Day15 : Day2017
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var duel = new GeneratorDuel(679, 771);
            duel.Run(40_000_000);
            Console.WriteLine($"Final count part 1: {duel.FinalCount}");

            WritePartTitle();
            var duel2 = new GeneratorDuel(679, 771);
            duel2.Run2(5_000_000);
            Console.WriteLine($"Final count part 2: {duel2.FinalCount}");
        }
    }
}