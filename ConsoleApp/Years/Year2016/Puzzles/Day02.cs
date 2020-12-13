using System;
using Core.BathroomSecurity;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day02 : Day2016
    {
        public Day02() : base(2)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var squareCodeFinder = new SquareKeyCodeFinder();
            var squareCode = squareCodeFinder.Find(FileInput);
            return new PuzzleResult(squareCode, "61529");
        }

        public override PuzzleResult RunPart2()
        {
            var diamondCodeFinder = new DiamondKeyCodeFinder();
            var diamondCode = diamondCodeFinder.Find(FileInput);
            return new PuzzleResult(diamondCode, "C2C28");
        }
    }
}