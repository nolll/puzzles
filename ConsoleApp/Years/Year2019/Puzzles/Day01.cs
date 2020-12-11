using System;
using Core.ModuleMass;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day01 : Day2019
    {
        public Day01() : base(1)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var massCalculator = new MassCalculator(FileInput);
            return new PuzzleResult($"Required fuel: {massCalculator.MassFuel}");
        }

        public override PuzzleResult RunPart2()
        {
            var massCalculator = new MassCalculator(FileInput);
            return new PuzzleResult($"Required total fuel: {massCalculator.TotalFuel}");
        }
    }
}