using NUnit.Framework;

namespace Euler.Puzzles.Euler008;

public class Euler008Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler008();
        var result = puzzle.Run(4);

        Assert.That(result, Is.EqualTo(5832));
    }
}