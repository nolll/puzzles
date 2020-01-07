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
            var coin = miner.Mine(Input);
            Console.WriteLine($"Coin: {coin}");
        }

        private const string Input = "iwrupvqb";
    }
}