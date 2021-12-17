using NUnit.Framework;

namespace App.Puzzles.Year2015.Day04;

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