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
            return new PuzzleResult(collection.ResourceValue, 763_804);
        }

        public override PuzzleResult RunPart2()
        {
            var collection2 = new LumberCollection(FileInput);
            collection2.Run(1_000_000_000);
            return new PuzzleResult(collection2.ResourceValue, 188_400);
        }
    }
}