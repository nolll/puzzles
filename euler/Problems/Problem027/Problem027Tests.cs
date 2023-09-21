using NUnit.Framework;

namespace Euler.Problems.Problem027;

public class Problem027Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem027();
        var result = problem.GetPrimeCount(-79, 1601);

        Assert.That(result, Is.EqualTo(80));
    }
}