using NUnit.Framework;

namespace Euler.Puzzles.Euler026;

public class Euler026Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler026();
        var result = puzzle.Run(10);

        Assert.That(result, Is.EqualTo(7));
    }
}