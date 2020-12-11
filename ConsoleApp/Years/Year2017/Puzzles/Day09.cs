using System;
using Core.StreamProcessing;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day09 : Day2017
    {
        public Day09() : base(9)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var processor = new StreamProcessor(FileInput);
            return new PuzzleResult($"Total group score: {processor.Score}");
        }

        public override PuzzleResult RunPart2()
        {
            var processor = new StreamProcessor(FileInput);
            return new PuzzleResult($"Removed garbage: {processor.GarbageCount}");
        }
    }
}