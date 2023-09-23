using NUnit.Framework;

namespace Euler.Puzzles.Euler003;

public class Euler003Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler003();
        var result = puzzle.Run(13195);

        Assert.That(result, Is.EqualTo(29));
    }
}