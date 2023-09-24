using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201504;

public class Aoc201504Tests
{
    [TestCase("abcdef", 609043)]
    [TestCase("pqrstuv", 1048970)]
    public void CoinMined(string secretKey, int expected)
    {
        var coin = AdventCoinMiner.Mine(secretKey, 5);

        Assert.That(coin, Is.EqualTo(expected));
    }
}