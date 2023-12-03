using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler009;

public class Euler009Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler009();
        var result = puzzle.Run(12);

        result.Should().Be(60);
    }
}