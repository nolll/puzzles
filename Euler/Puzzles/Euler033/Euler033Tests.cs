namespace Pzl.Euler.Puzzles.Euler033;

public class Euler033Tests
{
    [Theory]
    [InlineData(34, 43, true)]
    [InlineData(34, 56, false)]
    public void CanBeReduced(int numerator, int denominator, bool result)
    {
        var fraction = new Fraction(numerator, denominator);

        fraction.CanBeReduced.Should().Be(result);
    }

    [Theory]
    [InlineData(34, 43, 1)]
    [InlineData(49, 98, 0.5)]
    [InlineData(17, 78, 0.125)]
    public void ReducedResult(int numerator, int denominator, double result)
    {
        var fraction = new Fraction(numerator, denominator);

        fraction.ReducedResult.Should().Be(result);
    }
}
