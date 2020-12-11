using System;
using Core.ExperimentalCompression;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day09 : Day2016
    {
        public Day09() : base(9)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var decompressor = new FileDecompressor(FileInput);
            return new PuzzleResult($"Decompressed length V1: {decompressor.DecompressedLengthV1}");
        }

        public override PuzzleResult RunPart2()
        {
            var decompressor = new FileDecompressor(FileInput);
            return new PuzzleResult($"Decompressed length V2: {decompressor.DecompressedLengthV2}");
        }
    }
}