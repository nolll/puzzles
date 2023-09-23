using NUnit.Framework;

namespace Euler.Puzzles.Euler016;

public class Euler016Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler016();
        var result = puzzle.Run(15);

        Assert.That(result, Is.EqualTo(26));
    }
}