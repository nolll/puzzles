using System;
using Core.BeverageBandits;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day15 : Day2018
    {
        public Day15() : base(15)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var battle = new ChocolateBattle(FileInput);
            battle.RunOnce(false);
            return new PuzzleResult(battle.Outcome, 246_176);
        }

        public override PuzzleResult RunPart2()
        {
            var battle2 = new ChocolateBattle(FileInput);
            battle2.RunUntilElvesWins(false);
            return new PuzzleResult(battle2.Outcome, 58_128);
        }
    }
}