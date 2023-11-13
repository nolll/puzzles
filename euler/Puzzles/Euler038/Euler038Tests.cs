using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.euler.Puzzles.Euler038;

public class Euler038Tests
{
    [TestCase(9, 918273645)]
    [TestCase(192, 192384576)]
    public void GetConcatenatedProduct(int n, long expected)
    {
        var result = Euler038.GetConcatenatedProduct(n);

        result.Should().Be(expected);
    }
}