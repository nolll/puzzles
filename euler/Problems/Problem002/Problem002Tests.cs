using NUnit.Framework;

namespace Euler.Problems.Problem002;

public class Problem002Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem002();
        var result = problem.Run(100);

        Assert.That(result, Is.EqualTo(44));
    }
}