using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler036;

public class Euler036Tests
{
    [TestCase(383, false)]
    [TestCase(585, true)]
    [TestCase(21, false)]
    public void IsPalindromeInBothBases(int input, bool expected)
    {
        var result = Euler036.IsPalindromeInBothBases(input);

        result.Should().Be(expected);
    }
}