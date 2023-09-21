using NUnit.Framework;

namespace Euler.Problems.Problem003;

public class Problem003Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem003();
        var result = problem.Run(13195);

        Assert.That(result, Is.EqualTo(29));
    }
}