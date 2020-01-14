using System;
using Core.MarbleMania;

namespace ConsoleApp.Years.Year2018
{
    public class Day09 : Day
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var game = new MarbleGame(404, 71852);
            Console.WriteLine($"Winner score 1: {game.WinnerScore}");

            WritePartTitle();
            var game2 = new MarbleGame(404, 7185200);
            Console.WriteLine($"Winner score 2: {game2.WinnerScore}");
        }
    }
}