using NUnit.Framework;

namespace Euler.Puzzles.Euler023;

public class Euler023Tests
{
    [Test]
    public void Test()
    {
        var result = Euler023.FindAbundantNumbers(13);

        Assert.That(result.Count(), Is.EqualTo(1));
    }
}