using System;
using Core.BathroomSecurity;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day02 : Day2016
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var squareCodeFinder = new SquareKeyCodeFinder();
            var squareCode = squareCodeFinder.Find(FileInput);
            Console.WriteLine($"Square keycode: {squareCode}");

            WritePartTitle();
            var diamondCodeFinder = new DiamondKeyCodeFinder();
            var diamonCode = diamondCodeFinder.Find(FileInput);
            Console.WriteLine($"Diamond keycode: {diamonCode}");
        }
    }
}