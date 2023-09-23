using NUnit.Framework;

namespace Euler.Puzzles.Euler025;

public class Euler025Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler025();
        var result = puzzle.Run(3);

        Assert.That(result, Is.EqualTo(12));
    }
}