using System;
using Core.TwoFactorAuth;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day08 : Day2016
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var simulator = new ScreenSimulator(50, 6);
            var simulatorResult = simulator.Run(FileInput);
            return new PuzzleResult($"Pixels on screen: {simulatorResult.PixelCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var simulator = new ScreenSimulator(50, 6);
            var simulatorResult = simulator.Run(FileInput);
            return new PuzzleResult($"Screen:\r\n{simulatorResult.PrintOut}");
        }
    }
}