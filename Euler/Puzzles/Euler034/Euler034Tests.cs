namespace Pzl.Euler.Puzzles.Euler034;

public class Euler034Tests
{
    [Theory]
    [InlineData(12, 3)]
    [InlineData(123, 9)]
    [InlineData(1234, 33)]
    [InlineData(145, 145)]
    public void DigitFactorialSum(int input, int expected)
    {
        var result = Euler034.GetDigitFactorialSum(input);

        result.Should().Be(expected);
    }
}