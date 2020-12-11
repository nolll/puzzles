using System;
using Core.RecursiveCircus;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day07 : Day2017
    {
        public Day07() : base(7)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var towers = new RecursiveTowers(FileInput);
            return new PuzzleResult($"Name of bottom tower: {towers.BottomName}");
        }

        public override PuzzleResult RunPart2()
        {
            var towers = new RecursiveTowers(FileInput);
            return new PuzzleResult($"Adjusted weight of disc with error: {towers.AdjustedWeight}");
        }
    }
}