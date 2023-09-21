using NUnit.Framework;

namespace Euler.Problems.Problem022;

public class Problem022Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem022();
        var result = problem.GetNameScore("COLIN");

        Assert.That(result, Is.EqualTo(49714));
    }
}