using NUnit.Framework;

namespace Euler.Puzzles.Euler005;

public class Euler005Tests
{
    [Test]
    public void Test()
    {
        var puzzle = new Euler005();
        var result = puzzle.Run(10);

        Assert.That(result, Is.EqualTo(2520));
    }
}