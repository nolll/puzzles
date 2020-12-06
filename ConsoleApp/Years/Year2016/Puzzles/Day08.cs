using System;
using Core.TwoFactorAuth;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day08 : Day2016
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new ScreenSimulator(50, 6);
            var simulatorResult = simulator.Run(FileInput);
            Console.WriteLine($"Pixels on screen: {simulatorResult.PixelCount}");

            WritePartTitle();
            Console.WriteLine("Screen:");
            Console.WriteLine(simulatorResult.PrintOut);
        }
    }
}