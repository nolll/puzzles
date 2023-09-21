using NUnit.Framework;

namespace Euler.Problems.Problem014;

public class Problem014Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem014();
        var result = problem.GenerateCollatzSequence(13);

        Assert.That(result.Count(), Is.EqualTo(10));
    }
}