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
            Console.WriteLine($"Length of string: {game.Result.Length}");

        }

        private const string Input = "1113222113";
    }
}