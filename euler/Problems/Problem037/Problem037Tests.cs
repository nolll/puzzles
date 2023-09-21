using NUnit.Framework;

namespace Euler.Problems.Problem037;

public class Problem037Tests
{
    [TestCase(1061, false)]
    [TestCase(3797, true)]
    public void IsTruncatable(int n, bool expected)
    {
        var result = Problem037.IsTruncatable(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}