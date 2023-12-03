using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler015;

public class Euler015Tests
{
    [TestCase(2, 6)]
    [TestCase(3, 20)]
    [TestCase(4, 70)]
    public void Test(int gridSize, long expected)
    {
        var puzzle = new Euler015();
        var result = puzzle.Run(gridSize);

        result.Should().Be(expected);
    }
}