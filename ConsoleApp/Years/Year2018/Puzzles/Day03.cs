using System;
using Core.SantasSuit;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day03 : Day2018
    {
        public Day03() : base(3)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(FileInput);
            return new PuzzleResult($"Overlap count: {claimsOverlapCountPuzzle.OverlapCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(FileInput);
            return new PuzzleResult($"No overlap id: {claimThatDoesNotOverlap.ClaimId}");
        }
    }
}