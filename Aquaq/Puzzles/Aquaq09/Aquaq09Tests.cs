using System.Numerics;
using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq09;

public class Aquaq09Tests
{
    [Fact]
    public void MultiplyLargeNumbers()
    {
        var input = new List<int> { 2, 4, 8 }.Select(o => new BigInteger(o));

        var result = Aquaq09.MultiplyLargeNumbers(input);

        result.Should().Be(new BigInteger(64));
    }
}