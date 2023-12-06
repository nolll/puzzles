using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Numbers;

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

        result.Should().Be(expected);
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

        result.Should().Be(expected);
    }

    [TestCase(1234567890, false)]
    [TestCase(1235, false)]
    [TestCase(1233, false)]
    [TestCase(1234, true)]
    public void IsPandigital1Through9(long n, bool expected)
    {
        var result = Numbers.IsPandigital1Through9(n);

        result.Should().Be(expected);
    }

    [TestCase(1234567890, true)]
    [TestCase(1234, false)]
    [TestCase(1233, false)]
    [TestCase(12340, true)]
    public void IsPandigital0Through9(long n, bool expected)
    {
        var result = Numbers.IsPandigital0Through9(n);

        result.Should().Be(expected);
    }

    [TestCase(1, 1)]
    [TestCase(2, 3)]
    [TestCase(3, 6)]
    [TestCase(4, 10)]
    [TestCase(5, 15)]
    public void GetTriangularNumber(int n, long expected)
    {
        Numbers.GetTriangularNumber(n).Should().Be(expected);
    }

    [TestCase(1, true)]
    [TestCase(3, true)]
    [TestCase(6, true)]
    [TestCase(10, true)]
    [TestCase(15, true)]
    [TestCase(16, false)]
    public void IsTriangularNumber(int n, bool expected)
    {
        Numbers.IsTriangularNumber(n).Should().Be(expected);
    }

    [TestCase(1, 1)]
    [TestCase(2, 5)]
    [TestCase(3, 12)]
    [TestCase(4, 22)]
    [TestCase(5, 35)]
    public void GetPentagonalNumber(int n, long expected)
    {
        Numbers.GetPentagonalNumber(n).Should().Be(expected);
    }

    [TestCase(1, true)]
    [TestCase(5, true)]
    [TestCase(12, true)]
    [TestCase(22, true)]
    [TestCase(35, true)]
    [TestCase(36, false)]
    public void IsPentagonalNumber(int n, bool expected)
    {
        Numbers.IsPentagonalNumber(n).Should().Be(expected);
    }

    [TestCase(1, 1)]
    [TestCase(2, 6)]
    [TestCase(3, 15)]
    [TestCase(4, 28)]
    [TestCase(5, 45)]
    public void GetHexagonalNumber(int n, long expected)
    {
        Numbers.GetHexagonalNumber(n).Should().Be(expected);
    }

    [TestCase(1, true)]
    [TestCase(6, true)]
    [TestCase(15, true)]
    [TestCase(28, true)]
    [TestCase(45, true)]
    [TestCase(46, false)]
    public void IsHexagonalNumber(int n, bool expected)
    {
        Numbers.IsHexagonalNumber(n).Should().Be(expected);
    }
}