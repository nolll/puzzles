using System;
using Core.KnotHash;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day10 : Day2017
    {
        public Day10() : base(10)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var intHasher = new IntKnotHasher(FileInput);
            return new PuzzleResult($"Int hash: {intHasher.Checksum}");
        }

        public override PuzzleResult RunPart2()
        {
            var asciiHasher = new AsciiKnotHasher(FileInput);
            return new PuzzleResult($"Ascii hash: {asciiHasher.Hash}");
        }
    }
}