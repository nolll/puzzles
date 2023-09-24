using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Day09;

public class Year2018Day09Tests
{
    [TestCase(10, 1618, 8317)]
    [TestCase(13, 7999, 146373)]
    [TestCase(17, 1104, 2764)]
    [TestCase(21, 6111, 54718)]
    [TestCase(30, 5807, 37305)]
    public void WinnerScoreIsCorrect(int playerCount, int lastMarbleValue, int expectedScore)
    {
        var game = new MarbleGame(playerCount, lastMarbleValue);

        Assert.That(game.WinnerScore, Is.EqualTo(expectedScore));
    }
}