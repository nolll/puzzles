using System;
using Core.ModuleMass;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day01 : Year2019Day
    {
        public override int Day => 1;

        public override PuzzleResult RunPart1()
        {
            var massCalculator = new MassCalculator(FileInput);
            return new PuzzleResult(massCalculator.MassFuel, 3_382_284);
        }

        public override PuzzleResult RunPart2()
        {
            var massCalculator = new MassCalculator(FileInput);
            return new PuzzleResult(massCalculator.TotalFuel, 5_070_541);
        }
    }
}