using System;
using Core.OneTimePad;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day14 : Day2016
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var generator = new KeyGenerator(Input);
            return new PuzzleResult($"Index of 64th key: {generator.IndexOf64thKey}");
        }

        public override PuzzleResult RunPart2()
        {
            var generator = new KeyGenerator(Input, true);
            return new PuzzleResult($"Index of 64th stretched key: {generator.IndexOf64thKey}");
        }

        private static string Input => "zpqevtbw";
    }
}