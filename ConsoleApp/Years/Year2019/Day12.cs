using System;
using Core.MoonTracking;

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
            var tracker1 = new MoonTracker(Input);
            const int iterations = 1000;
            tracker1.Run(iterations);

            Console.WriteLine($"Total energy after {iterations} time units: {tracker1.TotalEnergy}");

            WritePartTitle();
            var tracker2 = new MoonTracker(Input);
            tracker2.RunUntilRepeat();

            Console.WriteLine($"Time units until repeat: {tracker2.Iterations}");
        }

        private const string Input = @"<x=1, y=2, z=-9>
<x=-1, y=-9, z=-4>
<x=17, y=6, z=8>
<x=12, y=4, z=2>";
    }
}