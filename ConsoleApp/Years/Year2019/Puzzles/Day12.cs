using System;
using Core.MoonTracking;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day12 : Day2019
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tracker1 = new MoonTracker(FileInput);
            const int iterations = 1000;
            tracker1.Run(iterations);

            Console.WriteLine($"Total energy after {iterations} time units: {tracker1.TotalEnergy}");

            WritePartTitle();
            var tracker2 = new MoonTracker(FileInput);
            tracker2.RunUntilRepeat();

            Console.WriteLine($"Time units until repeat: {tracker2.Iterations}");
        }
    }
}