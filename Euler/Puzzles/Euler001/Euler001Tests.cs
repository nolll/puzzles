using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler001;

public class Euler001Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler001();
        var result = puzzle.Run(10);

        result.Should().Be(23);
    }
}