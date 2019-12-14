using System;
using Core.MoonTracking;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day12 : Day
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tracker1 = new MoonTracker(InputData.MoonPositions);
            const int iterations = 1000;
            tracker1.Run(iterations);

            Console.WriteLine($"Total energy after {iterations} time units: {tracker1.TotalEnergy}");

            WritePartTitle();
            var tracker2 = new MoonTracker(InputData.MoonPositions);
            tracker2.Run(null);
            
            Console.WriteLine($"Time units until repeat: {tracker2.TotalCycleLength}");
        }
    }
}