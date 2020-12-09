using System;
using Core.SleepingGuards;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day04 : Day2018
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
            Console.WriteLine($"Guard sleep strategy two score: {guardSleepPuzzle.StrategyOneScore}");

            WritePartTitle();
            Console.WriteLine($"Guard sleep strategy two score: {guardSleepPuzzle.StrategyTwoScore}");
        }
    }
}