namespace Pzl.Tools.Maths;

public class MathToolsTests
{
    [Theory]
    [InlineData(9, 9, 3)]
    [InlineData(90915, 435, 33, 57)]
    [InlineData(616, 2, 4, 8, 77)]
    [InlineData(616, 2, 8, 77)]
    public void FindsLcm(long expected, params long[] numbers) => MathTools.Lcm(numbers).Should().Be(expected);

    [Theory]
    [InlineData(10, new[] { 1, 2, 5, 10 })]
    [InlineData(12, new[] { 1, 2, 3, 4, 6, 12 })]
    [InlineData(25, new[] { 1, 5, 25 })]
    [InlineData(99, new[] { 1, 3, 9, 11, 33, 99 })]
    [InlineData(45, new[] { 1, 3, 5, 9, 15, 45 })]
    [InlineData(20, new[] { 1, 2, 4, 5, 10, 20 })]
    [InlineData(11, new[] { 1, 11 })]
    [InlineData(17, new[] { 1, 17 })]
    public void GetFactors(int input, int[] expected) => 
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
}