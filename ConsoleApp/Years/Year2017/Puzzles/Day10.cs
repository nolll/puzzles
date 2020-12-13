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
            return new PuzzleResult(intHasher.Checksum, 2928);
        }

        public override PuzzleResult RunPart2()
        {
            var asciiHasher = new AsciiKnotHasher(FileInput);
            return new PuzzleResult(asciiHasher.Hash, "0c2f794b2eb555f7830766bf8fb65a16");
        }
    }
}