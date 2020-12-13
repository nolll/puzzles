using System;
using Core.DuelingGenerators;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day15 : Day2017
    {
        public Day15() : base(15)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var duel = GeneratorDuel.Parse(FileInput);
            duel.Run(40_000_000);
            return new PuzzleResult(duel.FinalCount, 626);
        }

        public override PuzzleResult RunPart2()
        {
            var duel2 = GeneratorDuel.Parse(FileInput);
            duel2.Run2(5_000_000);
            return new PuzzleResult(duel2.FinalCount, 306);
        }
    }
}