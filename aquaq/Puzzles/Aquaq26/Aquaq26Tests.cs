using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq26;

public class Aquaq26Tests
{
    [TestCase("1423", "1432")]
    [TestCase("121", "211")]
    [TestCase("10290", "10902")]
    [TestCase("4321", "4321")]
    public void FindFirstLargestNumber(string input, string expected) => 
        Aquaq26.FindFirstLargerNumber(BigInteger.Parse(input))
            .Should().Be(BigInteger.Parse(expected));
}