using NUnit.Framework;

namespace Euler.Puzzles.Euler001;

public class Euler001Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler001();
        var result = puzzle.Run(10);

        Assert.That(result, Is.EqualTo(23));
    }
}