using System;
using Core.NavigationSystemLicense;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day08 : Day2018
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new LicenseNumberCalculator(FileInput);
            return new PuzzleResult($"Metadata sum: {calculator.MetadataSum}");
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new LicenseNumberCalculator(FileInput);
            return new PuzzleResult($"Root node value: {calculator.RootNodeValue}");
        }
    }
}