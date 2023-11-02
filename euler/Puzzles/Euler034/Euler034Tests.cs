using FluentAssertions;
using NUnit.Framework;

namespace Euler.Puzzles.Euler034;

public class Euler034Tests
{
    [TestCase(12, 3)]
    [TestCase(123, 9)]
    [TestCase(1234, 33)]
    [TestCase(145, 145)]
    public void DigitFactorialSum(int input, int expected)
    {
        var result = Euler034.GetDigitFactorialSum(input);

        result.Should().Be(expected);
    }
}