using System;
using Core.RecursiveCircus;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day07 : Day2017
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var towers = new RecursiveTowers(FileInput);
            Console.WriteLine($"Name of bottom tower: {towers.BottomName}");

            WritePartTitle();
            Console.WriteLine($"Adjusted weight of disc with error: {towers.AdjustedWeight}");
        }
    }
}