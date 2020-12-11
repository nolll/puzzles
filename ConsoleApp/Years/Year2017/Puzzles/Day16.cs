using System;
using Core.LineDance;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day16 : Day2017
    {
        public Day16() : base(16)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var dancingPrograms1 = new DancingPrograms();
            dancingPrograms1.Dance(FileInput, 1);
            return new PuzzleResult($"Programs after one dance: {dancingPrograms1.Programs}");
        }

        public override PuzzleResult RunPart2()
        {
            var dancingPrograms2 = new DancingPrograms();
            dancingPrograms2.Dance(FileInput, 1_000_000_000);
            return new PuzzleResult($"Programs after one billion dances: {dancingPrograms2.Programs}");
        }
    }
}