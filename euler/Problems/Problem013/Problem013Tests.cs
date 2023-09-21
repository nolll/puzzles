using NUnit.Framework;

namespace Euler.Problems.Problem013;

public class Problem013Tests
{
    [Test]
    public void Test()
    {
        const string numbers = @"
10000000000000000000000000000000000000000000000000
20000000000000000000000000000000000000000000000000
30000000000000000000000000000000000000000000000000";

        var problem = new Problem013();
        var result = problem.Run(numbers);

        Assert.That(result, Is.EqualTo("6000000000"));
    }
}