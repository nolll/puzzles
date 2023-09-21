using NUnit.Framework;

namespace Euler.Problems.Problem026;

public class Problem026Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem026();
        var result = problem.Run(10);

        Assert.That(result, Is.EqualTo(7));
    }
}