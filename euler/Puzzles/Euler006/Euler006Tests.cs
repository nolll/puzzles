using NUnit.Framework;

namespace Euler.Puzzles.Euler006;

public class Euler006Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler006();
        var result = puzzle.Run(10);

        Assert.That(result, Is.EqualTo(2640));
    }
}