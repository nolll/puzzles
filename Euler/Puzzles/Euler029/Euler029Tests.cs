using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler029;

public class Euler029Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler029();
        var result = puzzle.Run(5);

        result.Should().Be(15);
    }
}