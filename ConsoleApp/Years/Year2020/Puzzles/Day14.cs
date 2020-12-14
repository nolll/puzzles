﻿using Core.Bitmasking;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day14 : Day2020
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var system = new BitmaskSystem1();
            var sum = system.Run(FileInput);
            return new PuzzleResult(sum, 0);
        }

        public override PuzzleResult RunPart2()
        {
            var system = new BitmaskSystem2();
            var sum = system.Run(FileInput);
            return new PuzzleResult(sum, 0);
        }
    }
}