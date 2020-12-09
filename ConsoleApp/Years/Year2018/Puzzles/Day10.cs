using System;
using Core.AlignedStars;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day10 : Day2018
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var finder = new StarMessageFinder(FileInput, 9);
            Console.WriteLine("Message:");
            Console.WriteLine(finder.Message);
            
            WritePartTitle();
            Console.WriteLine($"Number of seconds: {finder.IterationCount}");
        }
    }
}