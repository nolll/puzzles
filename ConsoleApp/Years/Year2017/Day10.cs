using System;
using Core.KnotHash;

namespace ConsoleApp.Years.Year2017
{
    public class Day10 : Day
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var hasher = new KnotHasher(256, Input);
            Console.WriteLine($"Checksum: {hasher.Checksum}");
        }

        private const string Input = "230,1,2,221,97,252,168,169,57,99,0,254,181,255,235,167";
    }
}