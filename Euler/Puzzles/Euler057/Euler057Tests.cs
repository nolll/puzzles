namespace Pzl.Euler.Puzzles.Euler057;

public class Euler057Tests
{
    [Theory]
    [InlineData(1, 3, 2)]
    [InlineData(2, 7, 5)]
    [InlineData(3, 17, 12)]
    [InlineData(4, 41, 29)]
    [InlineData(8, 1393, 985)]
    public void Solve(int levels, int expectedNumerator, int expectedDenominator)
    {
        var result = Euler057.Solve(levels);
        result.Numerator.Should().Be(expectedNumerator);
        result.Denominator.Should().Be(expectedDenominator);
    }
}