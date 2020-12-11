using System;
using Core.Polymers;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day05 : Day2018
    {
        public Day05() : base(5)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var polymerPuzzle = new PolymerPuzzle(FileInput);
            return new PuzzleResult($"Reduced polymer length: {polymerPuzzle.ReducedPolymer.Length}");
        }

        public override PuzzleResult RunPart2()
        {
            var polymerPuzzle = new PolymerPuzzle(FileInput);
            return new PuzzleResult($"Improved polymer length: {polymerPuzzle.ImprovedPolymer.Length}");
        }
    }
}