﻿using Core.Common.Hashing;
using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2017.Day10
{
    public class Year2017Day10 : Year2017Day
    {
        public override int Day => 10;

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