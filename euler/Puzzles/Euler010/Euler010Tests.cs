using NUnit.Framework;

namespace Euler.Puzzles.Euler010;

public class Euler010Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler010();
        var result = puzzle.Run(10);

        Assert.That(result, Is.EqualTo(17));
    }
}