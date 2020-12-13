using System;
using Core.HandheldGameConsole;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day08 : Day2020
    {
        public Day08() : base(8)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var console = new GameConsoleRunner(FileInput);
            var acc = console.RunUntilLoop();
            return new PuzzleResult(acc, 1446);
        }

        public override PuzzleResult RunPart2()
        {
            var console = new GameConsoleRunner(FileInput);
            var acc = console.RunUntilTermination();
            return new PuzzleResult(acc, 1403);
        }
    }
}