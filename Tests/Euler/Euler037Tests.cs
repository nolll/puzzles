using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler037Tests
{
    [Theory]
    [InlineData(1061, false)]
    [InlineData(3797, true)]
    public void IsTruncatable(int n, bool expected)
    {
        var result = Euler037.IsTruncatable(n);

        result.Should().Be(expected);
    }
}