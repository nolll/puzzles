using FluentAssertions;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq33;

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
    public void PlayOneGame(int target, int expected)
    {
        var result = Aquaq33.Play(target);

        result.Should().Be(expected);
    }
}