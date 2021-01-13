using System;
using Core.OneTimePad;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day14 : Day2016
    {
        public override string Comment => "Slow hashing";
        public override bool IsSlow => true;

        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey(Input);
            
            return new PuzzleResult(index, 16_106);
        }

        public override PuzzleResult RunPart2()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey(Input, 2016);
            
            return new PuzzleResult(index, 22_423);
        }

        private static string Input => "zpqevtbw";
    }
}