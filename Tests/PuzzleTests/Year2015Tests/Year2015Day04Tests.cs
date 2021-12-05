using ConsoleApp.Years.Year2015.Puzzles;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2015Tests
{
    public class Year2015Day04Tests
    {
        [TestCase("abcdef", 609043)]
        [TestCase("pqrstuv", 1048970)]
        public void CoinMined(string secretKey, int expected)
        {
            var miner = new AdventCoinMiner();
            var coin = miner.Mine(secretKey, 5);

            Assert.That(coin, Is.EqualTo(expected));
        }
    }
}