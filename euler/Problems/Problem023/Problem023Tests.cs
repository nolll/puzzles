using NUnit.Framework;

namespace Euler.Problems.Problem023;

public class Problem023Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem023();
        var result = Problem023.FindAbundantNumbers(13);

        Assert.That(result.Count(), Is.EqualTo(1));
    }
}