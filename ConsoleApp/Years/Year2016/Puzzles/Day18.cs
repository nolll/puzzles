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
            detector.FindTraps(40);
            return new PuzzleResult($"Number of safe tiles after 40 rows: {detector.SafeCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var detector = new FloorTrapDetector(FileInput);
            detector.FindTraps(400_000);
            return new PuzzleResult($"Number of safe tiles after 400000 rows: {detector.SafeCount}");
        }
    }
}