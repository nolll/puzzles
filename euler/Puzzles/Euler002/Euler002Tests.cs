using NUnit.Framework;

namespace Euler.Puzzles.Euler002;

public class Euler002Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler002();
        var result = puzzle.Run(100);

        Assert.That(result, Is.EqualTo(44));
    }
}