using System;
using Core.Thrust;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day07 : Day2019
    {
        public Day07() : base(7)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new ThrustCalculator(FileInput);
            var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
            return new PuzzleResult(maxThrust1, 255_590);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new ThrustCalculator(FileInput);
            var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
            return new PuzzleResult(maxThrust2, 58_285_150);
        }
    }
}