using NUnit.Framework;

namespace Euler.Problems.Problem021;

public class Problem021Tests
{
    [Test]
    public void Test()
    {
        const int a = 220;
        const int b = 284;

        var problem = new Problem021();
        var sumA = Problem021.GetFactorialSum(a);
        var sumB = Problem021.GetFactorialSum(b);

        Assert.That(sumA, Is.EqualTo(b));
        Assert.That(sumB, Is.EqualTo(a));
    }
}