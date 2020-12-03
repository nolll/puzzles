using System;
using Core.KnotHash;

namespace ConsoleApp.Years.Year2017.Days
{
    public class Day10 : Day2017
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var intHasher = new IntKnotHasher(Input);
            Console.WriteLine($"Int hash: {intHasher.Checksum}");

            WritePartTitle();
            var asciiHasher = new AsciiKnotHasher(Input);
            Console.WriteLine($"Ascii hash: {asciiHasher.Hash}");
        }

        protected override string Input => "230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167";
    }
}