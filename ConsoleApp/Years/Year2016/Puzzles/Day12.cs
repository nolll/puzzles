using System;
using Core.Monorail;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day12 : Day2016
    {
        public Day12() : base(12)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer = new MonorailComputer(FileInput, 0, 0);
            return new PuzzleResult(computer.ValueA, 318_003);
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new MonorailComputer(FileInput, 0, 1);
            return new PuzzleResult(computer.ValueA, 9_227_657);
        }
    }
}