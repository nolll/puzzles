using FluentAssertions;
using NUnit.Framework;

namespace Euler.Puzzles.Euler004;

public class Euler004Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler004();
        var result = puzzle.Run(10, 99);

        result.Should().Be(9009);
    }
}