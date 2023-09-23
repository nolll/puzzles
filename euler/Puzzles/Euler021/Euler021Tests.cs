using NUnit.Framework;

namespace Euler.Puzzles.Euler021;

public class Euler021Tests
{
    [Test]
    public void Test()
    {
        const int a = 220;
        const int b = 284;

        var sumA = Euler021.GetFactorialSum(a);
        var sumB = Euler021.GetFactorialSum(b);

        Assert.That(sumA, Is.EqualTo(b));
        Assert.That(sumB, Is.EqualTo(a));
    }
}