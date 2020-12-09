using System;
using Core.SantasSuit;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day03 : Day2018
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var claimsOverlapCountPuzzle = new ClaimsOverlapCountPuzzle(FileInput);
            Console.WriteLine($"Overlap count: {claimsOverlapCountPuzzle.OverlapCount}");

            WritePartTitle();
            var claimThatDoesNotOverlap = new ClaimThatDoesNotOverlapPuzzle(FileInput);
            Console.WriteLine($"No overlap id: {claimThatDoesNotOverlap.ClaimId}");
        }
    }
}