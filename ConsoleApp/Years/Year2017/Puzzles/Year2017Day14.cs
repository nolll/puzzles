using System;
using Core.DiskFragmentation;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Year2017Day14 : Year2017Day
    {
        public override int Day => 14;

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