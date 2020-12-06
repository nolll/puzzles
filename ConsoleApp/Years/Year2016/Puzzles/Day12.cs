using System;
using Core.Monorail;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day12 : Day2016
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var control1 = new MonorailComputer(FileInput, 0, 0);
            Console.WriteLine($"Value in register A: {control1.ValueA}");

            WritePartTitle();
            var control2 = new MonorailComputer(FileInput, 0, 1);
            Console.WriteLine($"Value in register A: {control2.ValueA}");
        }
    }
}