using NUnit.Framework;

namespace Euler.Puzzles.Euler027;

public class Euler027Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler027();
        var result = puzzle.GetPrimeCount(-79, 1601);

        Assert.That(result, Is.EqualTo(80));
    }
}