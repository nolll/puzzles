using NUnit.Framework;

namespace Euler.Problems.Problem018;

public class Problem018Tests
{
    [Test]
    public void Test()
    {
        const string triangle = @"
3
7 4
2 4 6
8 5 9 3";

        var problem = new Problem018();
        var result = problem.Run(triangle);

        Assert.That(result, Is.EqualTo(23));
    }
}