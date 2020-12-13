using System;
using Core.SeriesOfTubes;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day19 : Day2017
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var finder = new TubeRouteFinder(FileInput);
            finder.FindRoute();
            return new PuzzleResult(finder.Route, "PVBSCMEQHY");
        }

        public override PuzzleResult RunPart2()
        {
            var finder = new TubeRouteFinder(FileInput);
            finder.FindRoute();
            return new PuzzleResult(finder.StepCount, 17_736);
        }
    }
}