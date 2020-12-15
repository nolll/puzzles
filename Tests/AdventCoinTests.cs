using Core.AdventCoins;
using NUnit.Framework;

namespace Tests
{
    public class AdventCoinTests
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