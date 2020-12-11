using System;
using Core.AircraftBoarding;
using Core.CustomDeclarations;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day06 : Day2020
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var reader = new DeclarationFormReader(FileInput);
            return new PuzzleResult($"Sum of at least one 'yes' answer: {reader.SumOfAtLeastOneYes}");
        }

        public override PuzzleResult RunPart2()
        {
            var reader = new DeclarationFormReader(FileInput);
            return new PuzzleResult($"Sum of all 'yes' answer: {reader.SumOfAllYes}");
        }
    }
}