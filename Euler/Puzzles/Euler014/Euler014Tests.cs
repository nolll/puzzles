using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler014;

public class Euler014Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler014();
        var result = puzzle.GenerateCollatzSequence(13);

        result.Count().Should().Be(10);
    }
}