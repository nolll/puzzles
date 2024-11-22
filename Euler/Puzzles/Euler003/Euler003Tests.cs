using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler003;

public class Euler003Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler003();
        var result = puzzle.Run(13195);

        result.Should().Be(29);
    }
}