using System;
using Core.IntersectionFinder;
using Core.Tools;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day03 : Day2019
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            var wirePaths = PuzzleInputReader.ReadLines(FileInput);
            var wirePathA = wirePaths[0];
            var wirePathB = wirePaths[1];
            
            WritePartTitle();
            var intersectionFinder = new IntersectionFinder(wirePathA, wirePathB);
            var distance = intersectionFinder.ClosestIntersection.Distance;
            Console.WriteLine($"The distance of the closest intersection is: {distance}");

            WritePartTitle();
            var steps = intersectionFinder.FewestSteps.Steps;
            Console.WriteLine($"The fewest combined steps to the closest intersection is: {steps}");
        }
    }
}