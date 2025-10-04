using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler057;

public class Euler057Tests
{
    [TestCase(1, 3, 2)]
    [TestCase(2, 7, 5)]
    [TestCase(3, 17, 12)]
    [TestCase(4, 41, 29)]
    [TestCase(8, 1393, 985)]
    public void Solve(int levels, int expectedNumerator, int expectedDenominator)
    {
        var result = Euler057.Solve(levels);
        result.Numerator.Should().Be(expectedNumerator);
        result.Denominator.Should().Be(expectedDenominator);
    }
}