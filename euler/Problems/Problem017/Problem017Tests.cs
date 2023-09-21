using NUnit.Framework;

namespace Euler.Problems.Problem017;

public class Problem017Tests
{
    [Test]
    public void Test()
    {
        var problem = new Problem017();
        var result = problem.Run(5);

        Assert.That(result, Is.EqualTo(19));
    }
}