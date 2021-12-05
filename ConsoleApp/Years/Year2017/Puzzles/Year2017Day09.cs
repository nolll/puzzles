using System;
using Core.StreamProcessing;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Year2017Day09 : Year2017Day
    {
        public override int Day => 9;

        public override PuzzleResult RunPart1()
        {
            var processor = new StreamProcessor(FileInput);
            return new PuzzleResult(processor.Score, 14_421);
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new StreamProcessor(FileInput);
            return new PuzzleResult(processor.GarbageCount, 6817);
        }
    }
}