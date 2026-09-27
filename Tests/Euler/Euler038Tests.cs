using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler038Tests
{
    [Theory]
    [InlineData(9, 918273645)]
    [InlineData(192, 192384576)]
    public void GetConcatenatedProduct(int n, long expected)
    {
        var result = Euler038.GetConcatenatedProduct(n);

        result.Should().Be(expected);
    }
}