using FluentAssertions;
using NUnit.Framework;

namespace Euler.Puzzles.Euler020;

public class Euler020Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler020();
        var result = puzzle.Run(10);

        result.Should().Be(27);
    }
}