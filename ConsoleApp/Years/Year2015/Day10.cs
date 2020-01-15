using System;
using Core.LookAndSay;

namespace ConsoleApp.Years.Year2015
{
    public class Day10 : Day
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var game = new LookAndSayGame(Input, 40);
            Console.WriteLine($"Length of string 1: {game.Result.Length}");

            WritePartTitle();
            var game2 = new LookAndSayGame(Input, 50);
            Console.WriteLine($"Length of string 2: {game2.Result.Length}");
        }

        private const string Input = "1113222113";
    }
}