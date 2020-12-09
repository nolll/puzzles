﻿using System;
using Core.Lumber;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day18 : Day2018
    {
        public Day18() : base(18)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var collection = new LumberCollection(FileInput);
            collection.Run(10);
            Console.WriteLine($"Resource value after 10 minutes: {collection.ResourceValue}");

            WritePartTitle();
            var collection2 = new LumberCollection(FileInput);
            collection2.Run(1_000_000_000);
            Console.WriteLine($"Resource value after 1 billion minutes: {collection2.ResourceValue}");
        }
    }
}