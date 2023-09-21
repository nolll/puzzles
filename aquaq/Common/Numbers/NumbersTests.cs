using NUnit.Framework;

namespace AquaQ.Common.Numbers;

public class NumbersTests
{
    [TestCase(1, false)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    [TestCase(6, false)]
    [TestCase(7, true)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(10, false)]
    [TestCase(11, true)]
    [TestCase(12, false)]
    public void IsPrime(int n, bool expected)
    {
        var result = Numbers.IsPrime(n);

        Assert.That(result, Is.EqualTo(result));
    }

    [TestCase(1, 1)]
    [TestCase(3, 2)]
    [TestCase(6, 4)]
    [TestCase(10, 4)]
    [TestCase(15, 4)]
    [TestCase(21, 4)]
    [TestCase(28, 6)]
    public void Factors(int n, int expected)
    {
        var factors = Numbers.GetAllDivisors(n);
        var result = factors.Count();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1234567890, false)]
    [TestCase(1235, false)]
    [TestCase(1233, false)]
    [TestCase(1234, true)]
    public void IsPandigital1Through9(long n, bool expected)
    {
        var result = Numbers.IsPandigital1Through9(n);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1234567890, true)]
    [TestCase(1234, false)]
    [TestCase(1233, false)]
    [TestCase(12340, true)]
    public void IsPandigital0Through9(long n, bool expected)
    {
        var result = Numbers.IsPandigital0Through9(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}