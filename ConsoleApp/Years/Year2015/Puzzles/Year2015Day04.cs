using Core.AdventCoins;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Year2015Day04 : Year2015Day
    {
        private int _index;
        public override int Day => 4;

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