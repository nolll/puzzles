using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler008;

public class Euler008Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler008();
        var result = puzzle.Run(4);

        result.Should().Be(5832);
    }
}