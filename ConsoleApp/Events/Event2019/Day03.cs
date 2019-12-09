using System;
using ConsoleApp.Inputs;
using Core.IntersectionFinder;

namespace ConsoleApp.Events.Event2019
{
    public class Day03 : Day
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var intersectionFinder = new IntersectionFinder(InputData.WirePathA, InputData.WirePathB);
            var distance = intersectionFinder.ClosestIntersection.Distance;
            Console.WriteLine($"The distance of the closest intersection is: {distance}");

            WritePartTitle();
            var steps = intersectionFinder.FewestSteps.Steps;
            Console.WriteLine($"The fewest combined steps to the closest intersection is: {steps}");

        }
    }
}