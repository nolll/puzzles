using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day04;

public class Year2015Day04Tests
{
    [TestCase("abcdef", 609043)]
    [TestCase("pqrstuv", 1048970)]
    public void CoinMined(string secretKey, int expected)
    {
        var coin = AdventCoinMiner.Mine(secretKey, 5);

        Assert.That(coin, Is.EqualTo(expected));
    }
}