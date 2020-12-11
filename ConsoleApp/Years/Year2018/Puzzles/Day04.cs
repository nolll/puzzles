using System;
using Core.SleepingGuards;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day04 : Day2018
    {
        public Day04() : base(4)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
            return new PuzzleResult($"Guard sleep strategy two score: {guardSleepPuzzle.StrategyOneScore}");
        }

        public override PuzzleResult RunPart2()
        {
            var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
            return new PuzzleResult($"Guard sleep strategy two score: {guardSleepPuzzle.StrategyTwoScore}");
        }
    }
}