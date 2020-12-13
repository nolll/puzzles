using System;
using Core.DiskFragmentation;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day14 : Day2017
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var defragmenter = new DiskDefragmenter(Input);
            return new PuzzleResult(defragmenter.UsedCount, 8222);
        }

        public override PuzzleResult RunPart2()
        {
            var defragmenter = new DiskDefragmenter(Input);
            return new PuzzleResult(defragmenter.RegionCount, 1086);
        }

        private const string Input = "amgozmfv";
    }
}