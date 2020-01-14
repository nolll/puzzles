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
            Console.WriteLine($"Winner score: {game.WinnerScore}");
        }
    }
}