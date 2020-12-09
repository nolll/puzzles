using System;
using Core.ChronalCoordinates;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day06 : Day2018
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var finder = new LargestAreaFinder(FileInput);
            var size1 = finder.GetSizeOfLargestArea();
            Console.WriteLine($"Size of largest area: {size1}");

            WritePartTitle();
            var size2 = finder.GetSizeOfCentralArea(10000);
            Console.WriteLine($"Size of central area: {size2}");
        }
    }
}