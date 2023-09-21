using NUnit.Framework;

namespace Euler.Problems.Problem011;

public class Problem011Tests
{
    [Test]
    public void Test()
    {
        const string grid = @"
01 01 01 01 01
01 02 02 02 01
01 02 02 02 01
01 02 02 03 01
01 01 01 01 04";

        var problem = new Problem011();
        var result = problem.Run(grid);

        Assert.That(result, Is.EqualTo(48));
    }
}