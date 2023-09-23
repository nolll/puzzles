using NUnit.Framework;

namespace Euler.Puzzles.Euler031;

public class Euler031Tests
{
    [Test]
    public void TwoDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2 }, 2);

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void ThreeDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5 }, 5);

        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void FourDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5, 10 }, 10);

        Assert.That(result, Is.EqualTo(11));
    }
}