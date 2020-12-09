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
            var invalidNumber = port.FindFirstInvalidNumber();
            Console.WriteLine($"First invalid number: {invalidNumber}");

            WritePartTitle();
            var weakness = port.FindWeakness();
            Console.WriteLine($"First invalid number: {weakness}");
        }
    }
}