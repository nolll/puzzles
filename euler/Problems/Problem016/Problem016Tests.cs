using NUnit.Framework;

namespace Euler.Problems.Problem016;

public class Problem016Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem016();
        var result = problem.Run(15);

        Assert.That(result, Is.EqualTo(26));
    }
}