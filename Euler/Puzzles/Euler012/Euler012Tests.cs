using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler012;

public class Euler012Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler012();
        var result = puzzle.Run(5);

        result.Should().Be(28);
    }
}