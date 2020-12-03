using System;
using Core.DiskFragmentation;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day14 : Day2017
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var defragmenter = new DiskDefragmenter(LegacyInput);
            Console.WriteLine($"Used squares: {defragmenter.UsedCount}");

            WritePartTitle();
            Console.WriteLine($"Region count: {defragmenter.RegionCount}");
        }

        protected override string LegacyInput => "amgozmfv";
    }
}