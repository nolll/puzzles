using System;
using Core.CubicleMaze;

namespace ConsoleApp.Years.Year2016.Days
{
    public class Day13 : Day2016
    {
        public Day13() : base(13)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var maze1 = new Maze(50, 50, NumberInput);
            var stepCount = maze1.StepCountToTarget(31, 39);
            Console.WriteLine($"Required number of steps: {stepCount}");

            WritePartTitle();
            var maze2 = new Maze(75, 75, NumberInput);
            var locationCount = maze2.LocationCountAfter(50);
            Console.WriteLine($"Number of location: {locationCount}");
        }

        private const int NumberInput = 1362;
    }
}