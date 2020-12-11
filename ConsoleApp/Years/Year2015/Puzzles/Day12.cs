using System;
using Core.JsonAccounting;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day12 : Day2015
    {
        public Day12() : base(12)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var doc = new JsonDoc(FileInput, true);
            return new PuzzleResult($"Document sum: {doc.Sum}");
        }

        public override PuzzleResult RunPart2()
        {
            var doc = new JsonDoc(FileInput, false);
            return new PuzzleResult($"Document sum without red: {doc.Sum}");
        }
    }
}