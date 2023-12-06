using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler037;

public class Euler037Tests
{
    [TestCase(1061, false)]
    [TestCase(3797, true)]
    public void IsTruncatable(int n, bool expected)
    {
        var result = Euler037.IsTruncatable(n);

        result.Should().Be(expected);
    }
}