using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq33;

public class Aquaq33Tests
{
    [Test]
    public void ThrowDarts()
    {
        var result = Aquaq33.Run(30);

        result.Should().Be(32);
    }

    [TestCase(301, 6)]
    [TestCase(501, 9)]
    [TestCase(171, 3)]
    [TestCase(180, 3)]
    [TestCase(181, 4)]
    [TestCase(342, 6)]
    [TestCase(361, 7)]
    public void PlayOneGame(int target, int expected)
    {
        var dartGame = new DartGame();
        var result = dartGame.Play(target);

        result.Should().Be(expected);
    }
}