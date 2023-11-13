using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler010;

public class Euler010Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler010();
        var result = puzzle.Run(10);

        result.Should().Be(17);
    }
}