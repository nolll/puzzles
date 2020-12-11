using System;
using Core.Lumber;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day18 : Day2018
    {
        public Day18() : base(18)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var collection = new LumberCollection(FileInput);
            collection.Run(10);
            return new PuzzleResult($"Resource value after 10 minutes: {collection.ResourceValue}");
        }

        public override PuzzleResult RunPart2()
        {
            var collection2 = new LumberCollection(FileInput);
            collection2.Run(1_000_000_000);
            return new PuzzleResult($"Resource value after 1 billion minutes: {collection2.ResourceValue}");
        }
    }
}