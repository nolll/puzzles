using NUnit.Framework;

namespace Euler.Problems.Problem005;

public class Problem005Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem005();
        var result = problem.Run(10);

        Assert.That(result, Is.EqualTo(2520));
    }
}