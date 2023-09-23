using NUnit.Framework;

namespace Euler.Puzzles.Euler029;

public class Euler029Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler029();
        var result = puzzle.Run(5);

        Assert.That(result, Is.EqualTo(15));
    }
}