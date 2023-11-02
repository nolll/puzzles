using FluentAssertions;
using NUnit.Framework;

namespace Euler.Puzzles.Euler022;

public class Euler022Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler022();
        var result = puzzle.GetNameScore("COLIN");

        result.Should().Be(49714);
    }
}