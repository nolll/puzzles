using System;
using Core.BugLife;

namespace ConsoleApp.Years.Year2019
{
    public class Day24 : Day
    {
        public Day24() : base(24)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var simulator = new BugLifeSimulator(Input);
            simulator.RunUntilRepeat();

            Console.WriteLine($"Biodiversity rating: {simulator.BiodiversityRating}");

            WritePartTitle();
            var recursiveSimulator = new RecursiveBugLifeSimulator(Input);
            recursiveSimulator.Run(200);

            Console.WriteLine($"Bug count after 200 minutes: {recursiveSimulator.BugCount}");
        }

        private const string Input = @".#..#
#..##
##..#
##.##
#..##";
    }
}