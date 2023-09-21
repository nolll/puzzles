using NUnit.Framework;

namespace Euler.Problems.Problem020;

public class Problem020Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem020();
        var result = problem.Run(10);

        Assert.That(result, Is.EqualTo(27));
    }
}