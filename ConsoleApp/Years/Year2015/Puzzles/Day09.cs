using System;
using Core.SantasRoute;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day09 : Day2015
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new RouteCalculator(FileInput);
            Console.WriteLine($"Shortest route: {calculator.ShortestDistance}");

            WritePartTitle();
            Console.WriteLine($"Shortest route: {calculator.LongestDistance}");
        }
    }
}