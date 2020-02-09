using System;
using Core.DuelingGenerators;

namespace ConsoleApp.Years.Year2017
{
    public class Day15 : Day
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var duel = new GeneratorDuel(679, 771);
            duel.Run(40_000_000);
            Console.WriteLine($"Final count: {duel.FinalCount}");
        }
    }
}