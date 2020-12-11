using System;
using Core.MarbleMania;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day09 : Day2018
    {
        public Day09() : base(9)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var game = MarbleGame.Parse(FileInput);
            return new PuzzleResult($"Winner score 1: {game.WinnerScore}");
        }

        public override PuzzleResult RunPart2()
        {
            var game2 = MarbleGame.Parse(FileInput, 100);
            return new PuzzleResult($"Winner score 2: {game2.WinnerScore}");
        }
    }
}