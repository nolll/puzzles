using NUnit.Framework;

namespace Euler.Problems.Problem007;

public class Problem007Tests
{
    [Test]
    public void Test()
    {
        var problem = new Euler.Problems.Problem007.Problem007();
        var result = problem.Run(6);

        Assert.That(result, Is.EqualTo(13));
    }
}