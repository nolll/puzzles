using NUnit.Framework;

namespace Euler.Puzzles.Euler014;

public class Euler014Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler014();
        var result = puzzle.GenerateCollatzSequence(13);

        Assert.That(result.Count(), Is.EqualTo(10));
    }
}