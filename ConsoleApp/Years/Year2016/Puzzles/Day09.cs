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
            return new PuzzleResult(decompressor.DecompressedLengthV1, 107_035);
        }

        public override PuzzleResult RunPart2()
        {
            var decompressor = new FileDecompressor(FileInput);
            return new PuzzleResult(decompressor.DecompressedLengthV2, 11_451_628_995);
        }
    }
}