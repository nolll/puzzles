using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler028;

public class Euler028Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler028();
        var result = puzzle.Run(5);

        result.Should().Be(101);
    }
}