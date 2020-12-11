using Core.AdventCoins;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day04 : Day2015
    {
        public Day04() : base(4)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var miner = new AdventCoinMiner();
            var coin1 = miner.Mine(Input, 5);
            return new PuzzleResult($"Coin 1: {coin1}");
        }

        public override PuzzleResult RunPart2()
        {
            var miner = new AdventCoinMiner();
            var coin2 = miner.Mine(Input, 6);
            return new PuzzleResult($"Coin 2: {coin2}");
        }

        private const string Input = "iwrupvqb";
    }
}