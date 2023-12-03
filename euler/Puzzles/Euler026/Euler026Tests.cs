using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler026;

public class Euler026Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler026();
        var result = puzzle.Run(10);

        result.Should().Be(7);
    }
}