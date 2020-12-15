using Core.AdventCoins;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day04 : Day2015
    {
        private int _index;

        public Day04() : base(4)
        {
            _index = 0;
        }

        public override PuzzleResult RunPart1()
        {
            var miner = new AdventCoinMiner();
            var coin = miner.Mine(Input, 5);
            _index = coin;
            return new PuzzleResult(coin, 346_386);
        }

        public override PuzzleResult RunPart2()
        {
            var miner = new AdventCoinMiner();
            var coin = miner.Mine(Input, 6, _index);
            return new PuzzleResult(coin, 9_958_218);
        }

        private const string Input = "iwrupvqb";
    }
}