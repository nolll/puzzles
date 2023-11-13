using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler002;

public class Euler002Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler002();
        var result = puzzle.Run(100);

        result.Should().Be(44);
    }
}