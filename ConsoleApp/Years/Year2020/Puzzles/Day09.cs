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

        public override PuzzleResult RunPart1()
        {
            var port = new XmasPort(FileInput, 25);
            var invalidNumber = port.FindFirstInvalidNumber();
            return new PuzzleResult(invalidNumber, 32321523);
        }

        public override PuzzleResult RunPart2()
        {
            var port = new XmasPort(FileInput, 25);
            var weakness = port.FindWeakness();
            return new PuzzleResult(weakness, 4794981);
        }
    }
}