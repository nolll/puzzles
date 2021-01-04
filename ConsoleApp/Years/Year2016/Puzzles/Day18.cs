using System;
using Core.FloorTraps;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day18 : Day2016
    {
        public Day18() : base(18)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var detector = new FloorTrapDetector(FileInput);
            var safeCount = detector.CountSafeTiles(40);
            return new PuzzleResult(safeCount, 1989);
        }

        public override PuzzleResult RunPart2()
        {
            var detector = new FloorTrapDetector(FileInput);
            var safeCount = detector.CountSafeTiles(400_000);
            return new PuzzleResult(safeCount, 19_999_894);
        }
    }
}