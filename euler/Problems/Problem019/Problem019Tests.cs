using NUnit.Framework;

namespace Euler.Problems.Problem019;

public class Problem019Tests
{

    [Test]
    public void Test()
    {
        var startDate = DateTime.Parse("2020-01-01");
        var endDate = DateTime.Parse("2020-12-31");

        var problem = new Problem019();
        var result = problem.Run(startDate, endDate);

        Assert.That(result, Is.EqualTo(2));
    }
}