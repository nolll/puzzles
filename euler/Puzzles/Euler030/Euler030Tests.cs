using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler030;

public class Euler030Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler030();
        var result = puzzle.Run(4);

        result.Should().Be(19316);
    }
}
