using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201510;

public class Aoc201510Tests
{
    [TestCase("1", "11")]
    [TestCase("11", "21")]
    [TestCase("21", "1211")]
    [TestCase("1211", "111221")]
    [TestCase("111221", "312211")]
    public void CorrectSequence(string input, string expected)
    {
        var game = new LookAndSayGame(input, 1);

        Assert.That(game.Result, Is.EqualTo(expected));
    }
}