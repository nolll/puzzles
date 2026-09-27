namespace Tests.Euler.Puzzles.Euler037;

public class Euler037Tests
{
    [Theory]
    [InlineData(1061, false)]
    [InlineData(3797, true)]
    public void IsTruncatable(int n, bool expected)
    {
        var result = Pzl.Euler.Puzzles.Euler037.Euler037.IsTruncatable(n);

        result.Should().Be(expected);
    }
}