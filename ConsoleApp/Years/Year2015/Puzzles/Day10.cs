using System;
using Core.LookAndSay;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day10 : Day2015
    {
        public Day10() : base(10)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var game = new LookAndSayGame(Input, 40);
            return new PuzzleResult($"Length of string 1: {game.Result.Length}");
        }

        public override PuzzleResult RunPart2()
        {
            var game2 = new LookAndSayGame(Input, 50);
            return new PuzzleResult($"Length of string 2: {game2.Result.Length}");
        }

        private const string Input = "1113222113";
    }
}