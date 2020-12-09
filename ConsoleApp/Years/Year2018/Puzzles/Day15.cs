using System;
using Core.BeverageBandits;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day15 : Day2018
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            //WritePartTitle();
            //var battle = new ChocolateBattle(FileInput);
            //battle.RunOnce(false);
            //Console.WriteLine($"Battle outcome: {battle.Outcome}");

            WritePartTitle();
            var battle2 = new ChocolateBattle(FileInput);
            battle2.RunUntilElvesWins(false);
            Console.WriteLine($"Battle outcome when the elves win: {battle2.Outcome}");
        }
    }
}