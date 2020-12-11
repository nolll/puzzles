using System;
using Core.Duet;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day18 : Day2017
    {
        public Day18() : base(18)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var single = new SingleRunner(FileInput);
            single.Run();
            return new PuzzleResult($"Recovered frequency: {single.RecoveredFrequency}");
        }

        public override PuzzleResult RunPart2()
        {
            var duet = new DuetRunner(FileInput);
            duet.Run();
            return new PuzzleResult($"Program 1 send count: {duet.Program1SendCount}");
        }
    }
}