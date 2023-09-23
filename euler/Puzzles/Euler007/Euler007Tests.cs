using NUnit.Framework;

namespace Euler.Puzzles.Euler007;

public class Euler007Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler007();
        var result = puzzle.Run(6);

        Assert.That(result, Is.EqualTo(13));
    }
}