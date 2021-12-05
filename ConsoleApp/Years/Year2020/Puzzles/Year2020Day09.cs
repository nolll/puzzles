using System;
using Core.HandheldGameConsole;
using Core.XmasEncryption;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Year2020Day09 : Year2020Day
    {
        public override int Day => 9;

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