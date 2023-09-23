using NUnit.Framework;

namespace Euler.Puzzles.Euler009;

public class Euler009Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler009();
        var result = puzzle.Run(12);

        Assert.That(result, Is.EqualTo(60));
    }
}