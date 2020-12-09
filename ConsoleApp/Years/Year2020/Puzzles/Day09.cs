using System;
using Core.HandheldGameConsole;
using Core.XmasEncryption;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day09 : Day2020
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var port = new XmasPort(FileInput, 25);
            var number = port.FindFirstInvalidNumber();
            Console.WriteLine($"First invalid number: {number}");
        }
    }
}