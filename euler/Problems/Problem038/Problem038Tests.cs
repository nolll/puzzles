using NUnit.Framework;

namespace Euler.Problems.Problem038;

public class Problem038Tests
{
    [TestCase(9, 918273645)]
    [TestCase(192, 192384576)]
    public void GetConcatenatedProduct(int n, long expected)
    {
        var result = Problem038.GetConcatenatedProduct(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}