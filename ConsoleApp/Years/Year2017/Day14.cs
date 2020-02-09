﻿using System;
using Core.DiskFragmentation;

namespace ConsoleApp.Years.Year2017
{
    public class Day14 : Day
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var defragmenter = new DiskDefragmenter(Input);
            Console.WriteLine($"Used squares: {defragmenter.UsedCount}");

            WritePartTitle();
            Console.WriteLine($"Region count: {defragmenter.RegionCount}");
        }

        private const string Input = "amgozmfv";
    }
}