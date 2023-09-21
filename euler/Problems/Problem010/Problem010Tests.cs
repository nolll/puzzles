using NUnit.Framework;

namespace Euler.Problems.Problem010;

public class Problem010Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem010();
        var result = problem.Run(10);

        Assert.That(result, Is.EqualTo(17));
    }
}