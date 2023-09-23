using NUnit.Framework;

namespace Euler.Puzzles.Euler030;

public class Euler030Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler030();
        var result = puzzle.Run(4);

        Assert.That(result, Is.EqualTo(19316));
    }
}
