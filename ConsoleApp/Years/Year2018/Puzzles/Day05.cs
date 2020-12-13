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
            return new PuzzleResult(polymerPuzzle.ReducedPolymer.Length, 9172);
        }

        public override PuzzleResult RunPart2()
        {
            var polymerPuzzle = new PolymerPuzzle(FileInput);
            return new PuzzleResult(polymerPuzzle.ImprovedPolymer.Length, 6550);
        }
    }
}