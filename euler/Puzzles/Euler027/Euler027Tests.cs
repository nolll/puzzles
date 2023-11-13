using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler027;

public class Euler027Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler027();
        var result = puzzle.GetPrimeCount(-79, 1601);

        result.Should().Be(80);
    }
}