namespace Pzl.Tools.Maths;

public class MathToolsTests
{
    [Theory]
    [InlineData(9, 9L, 3L)]
    [InlineData(90915, 435L, 33L, 57L)]
    [InlineData(616, 2L, 4L, 8L, 77L)]
    [InlineData(616, 2L, 8L, 77L)]
    public void FindsLcm(long expected, params long[] numbers) => MathTools.Lcm(numbers).Should().Be(expected);

    [Theory]
    [InlineData(10, 1, 2, 5, 10)]
    [InlineData(12, 1, 2, 3, 4, 6, 12)]
    [InlineData(25, 1, 5, 25)]
    [InlineData(99, 1, 3, 9, 11, 33, 99)]
    [InlineData(45, 1, 3, 5, 9, 15, 45)]
    [InlineData(20, 1, 2, 4, 5, 10, 20)]
    [InlineData(11, 1, 11)]
    [InlineData(17, 1, 17)]
    public void GetFactors(int input, params int[] expected) => 
        MathTools.GetFactors(input).Should().BeEquivalentTo(expected);

    [Fact]
    public void GetMultiplicationFactors()
    {
        var result = MathTools.GetMultiplicationFactors(21);

        result.Count.Should().Be(2);
        result.First().Should().Be((1, 21));
        result.Last().Should().Be((3, 7));
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(-1, 99)]
    [InlineData(101, 1)]
    public void ClampInt(int input, int expected) => MathTools.Clamp(input, 1, 100).Should().Be(expected);

    [Theory]
    [InlineData(1, 1)]
    [InlineData(-1, 99)]
    [InlineData(101, 1)]
    public void ClampLong(long input, long expected) => MathTools.Clamp(input, 1, 100).Should().Be(expected);
    
    [Theory]
    [InlineData(1, 3, 2)]
    [InlineData(2, 7, 5)]
    [InlineData(3, 17, 12)]
    [InlineData(4, 41, 29)]
    [InlineData(8, 1393, 985)]
    public void ContinuedFractionSquareRootOfTwo(int levels, int expectedNumerator, int expectedDenominator)
    {
        var result = MathTools.ContinuedFraction(1, [2], levels);
        result.ToString().Should().Be($"{expectedNumerator}/{expectedDenominator}");
    }
    
    [Theory]
    [InlineData(1, 3, 1)]
    [InlineData(2, 8, 3)]
    [InlineData(3, 11, 4)]
    [InlineData(4, 19, 7)]
    [InlineData(5, 87, 32)]
    public void ContinuedFractionNaturalNumber(int levels, int expectedNumerator, int expectedDenominator)
    {
        var result = MathTools.ContinuedFraction(2, [1, 2, 1, 1, 4, 1, 1, 6, 1, 1, 8, 1, 1, 10, 1, 1], levels);
        result.ToString().Should().Be($"{expectedNumerator}/{expectedDenominator}");
    }
}