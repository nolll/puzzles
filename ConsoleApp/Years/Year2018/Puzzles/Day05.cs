using System;
using Core.Polymers;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day05 : Day2018
    {
        public override string Comment => "Polymer puzzle";

        public Day05() : base(5)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var polymerPuzzle = new PolymerPuzzle();
            var reducedPolymer = polymerPuzzle.GetReducedPolymer(FileInput);
            return new PuzzleResult(reducedPolymer.Length, 9172);
        }

        public override PuzzleResult RunPart2()
        {
            var polymerPuzzle = new PolymerPuzzle();
            var improvedPolymer = polymerPuzzle.GetImprovedPolymer(FileInput);
            return new PuzzleResult(improvedPolymer.Length, 6550);
        }
    }
}