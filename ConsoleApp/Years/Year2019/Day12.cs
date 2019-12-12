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
            var tracker = new MoonTracker(InputData.MoonPositions);
            tracker.Run(1000);

            Console.WriteLine($"Panels painted at least once: {tracker.TotalEnergy}");
        }
    }
}