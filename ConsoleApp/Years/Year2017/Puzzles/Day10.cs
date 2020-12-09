using System;
using Core.KnotHash;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day10 : Day2017
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var intHasher = new IntKnotHasher(FileInput);
            Console.WriteLine($"Int hash: {intHasher.Checksum}");

            WritePartTitle();
            var asciiHasher = new AsciiKnotHasher(FileInput);
            Console.WriteLine($"Ascii hash: {asciiHasher.Hash}");
        }
    }
}