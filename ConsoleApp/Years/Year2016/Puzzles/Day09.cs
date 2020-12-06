using System;
using Core.ExperimentalCompression;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day09 : Day2016
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var decompressor = new FileDecompressor(FileInput);
            Console.WriteLine($"Decompressed length V1: {decompressor.DecompressedLengthV1}");

            WritePartTitle();
            Console.WriteLine($"Decompressed length V2: {decompressor.DecompressedLengthV2}");
        }
    }
}