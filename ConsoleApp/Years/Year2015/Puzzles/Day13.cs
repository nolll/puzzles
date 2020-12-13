using System;
using Core.KnightsOfTheDinnerTable;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day13 : Day2015
    {
        public Day13() : base(13)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var table = new DinnerTable(FileInput);
            return new PuzzleResult(table.HappinessChange, 618);
        }

        public override PuzzleResult RunPart2()
        {
            var table = new DinnerTable(FileInput, true);
            return new PuzzleResult(table.HappinessChange, 601);
        }
    }
}