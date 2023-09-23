using NUnit.Framework;

namespace Euler.Puzzles.Euler017;

public class Euler017Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler017();
        var result = puzzle.Run(5);

        Assert.That(result, Is.EqualTo(19));
    }
}