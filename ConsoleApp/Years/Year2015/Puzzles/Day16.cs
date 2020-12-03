using System;
using Core.AuntSue;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day16 : Day2015
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sueSelector = new SueSelector(FileInput);
            Console.WriteLine($"Sue number, part 1: {sueSelector.SueNumberPart1}");

            WritePartTitle();
            Console.WriteLine($"Sue number, part 2: {sueSelector.SueNumberPart2}");
        }
    }
}