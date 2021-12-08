using System;
using Core.Platform;
using NUnit.Framework.Constraints;

namespace Core.Puzzles.Year2021.Day08
{
    public class Year2021Day08 : Year2021Day
    {
        
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var decoder = new SevenSegmentDisplayDecoder(FileInput);
            var result = decoder.GetEasyNumbers();
            return new PuzzleResult(result, 278);
        }

        public override PuzzleResult RunPart2()
        {
            var decoder = new SevenSegmentDisplayDecoder(FileInput);
            var result = decoder.GetDecodedSum();
            return new PuzzleResult(result, 986179);
        }
    }
}