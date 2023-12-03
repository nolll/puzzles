using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler005;

public class Euler005Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler005();
        var result = puzzle.Run(10);

        result.Should().Be(2520);
    }
}