using System;
using Core.Polymers;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day05 : Day2018
    {
        public Day05() : base(5)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var polymerPuzzle = new PolymerPuzzle(FileInput);
            Console.WriteLine($"Reduced polymer length: {polymerPuzzle.ReducedPolymer.Length}");

            WritePartTitle();
            Console.WriteLine($"Improved polymer length: {polymerPuzzle.ImprovedPolymer.Length}");
        }
    }
}