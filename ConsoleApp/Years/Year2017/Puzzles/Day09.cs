using System;
using Core.StreamProcessing;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day09 : Day2017
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor = new StreamProcessor(FileInput);
            Console.WriteLine($"Total group score: {processor.Score}");

            WritePartTitle();
            Console.WriteLine($"Removed garbage: {processor.GarbageCount}");
        }
    }
}