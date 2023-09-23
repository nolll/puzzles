using NUnit.Framework;

namespace Euler.Puzzles.Euler013;

public class Euler013Tests
{
    [Test]
    public void Test()
    {
        const string numbers = @"
10000000000000000000000000000000000000000000000000
20000000000000000000000000000000000000000000000000
30000000000000000000000000000000000000000000000000";

        var puzzle = new Euler013();
        var result = puzzle.Run(numbers);

        Assert.That(result, Is.EqualTo("6000000000"));
    }
}