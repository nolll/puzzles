using System;
using Core.AdventCoins;

namespace ConsoleApp.Years.Year2015
{
    public class Day04 : Day
    {
        public Day04() : base(4)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var miner = new AdventCoinMiner();
            var coin1 = miner.Mine(Input, 5);
            Console.WriteLine($"Coin 1: {coin1}");

            var coin2 = miner.Mine(Input, 6);
            Console.WriteLine($"Coin 2: {coin2}");
        }

        private const string Input = "iwrupvqb";
    }
}