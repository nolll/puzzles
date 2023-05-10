using NUnit.Framework;

namespace Aoc.Puzzles.Year2022.Day02;

public class Year2022Day02Tests
{
    [Test]
    public void Part1()
    {
        var game = new RockPaperScissors();
        var result = game.Part1(Input);

        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Part2()
    {
        var game = new RockPaperScissors();
        var result = game.Part2(Input);

        Assert.That(result, Is.EqualTo(12));
    }

    private const string Input = """
A Y
B X
C Z
""";
}