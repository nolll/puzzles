using NUnit.Framework;

namespace Euler.Problems.Problem015;

public class Problem015Tests
{
    [TestCase(2, 6)]
    [TestCase(3, 20)]
    [TestCase(4, 70)]
    public void Test(int gridSize, long expected)
    {
        var problem = new Problem015();
        var result = problem.Run(gridSize);

        Assert.That(result, Is.EqualTo(expected));
    }
}