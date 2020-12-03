using System;
using Core.BugLife;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day24 : Day2019
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new BugLifeSimulator(LegacyInput);
            simulator.RunUntilRepeat();

            Console.WriteLine($"Biodiversity rating: {simulator.BiodiversityRating}");

            WritePartTitle();
            var recursiveSimulator = new RecursiveBugLifeSimulator(LegacyInput);
            recursiveSimulator.Run(200);

            Console.WriteLine($"Bug count after 200 minutes: {recursiveSimulator.BugCount}");
        }

        protected override string LegacyInput => @".#..#
#..##
##..#
##.##
#..##";
    }
}