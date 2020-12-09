using System;
using Core.SeriesOfTubes;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day19 : Day2017
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var finder = new TubeRouteFinder(FileInput);
            finder.FindRoute();
            Console.WriteLine($"Letters found: {finder.Route}");

            WritePartTitle();
            Console.WriteLine($"Step count: {finder.StepCount}");
        }
    }
}