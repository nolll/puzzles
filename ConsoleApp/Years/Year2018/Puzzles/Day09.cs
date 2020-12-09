using System;
using Core.MarbleMania;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day09 : Day2018
    {
        public Day09() : base(9)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var game = MarbleGame.Parse(FileInput);
            Console.WriteLine($"Winner score 1: {game.WinnerScore}");

            WritePartTitle();
            var game2 = MarbleGame.Parse(FileInput, 100);
            Console.WriteLine($"Winner score 2: {game2.WinnerScore}");
        }
    }
}