using NUnit.Framework;

namespace Euler.Problems.Problem034;

public class Problem034Tests
{
    [TestCase(12, 3)]
    [TestCase(123, 9)]
    [TestCase(1234, 33)]
    [TestCase(145, 145)]
    public void DigitFactorialSum(int input, int expected)
    {
        var result = Problem034.GetDigitFactorialSum(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}