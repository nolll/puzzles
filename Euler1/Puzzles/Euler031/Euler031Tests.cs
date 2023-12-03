using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Euler.Puzzles.Euler031;

public class Euler031Tests
{
    [Test]
    public void TwoDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2 }, 2);

        result.Should().Be(2);
    }

    [Test]
    public void ThreeDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5 }, 5);

        result.Should().Be(4);
    }

    [Test]
    public void FourDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5, 10 }, 10);

        result.Should().Be(11);
    }
}