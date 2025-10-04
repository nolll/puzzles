namespace Pzl.Euler.Puzzles.Euler036;

public class Euler036Tests
{
    [Theory]
    [InlineData(383, false)]
    [InlineData(585, true)]
    [InlineData(21, false)]
    public void IsPalindromeInBothBases(int input, bool expected)
    {
        var result = Euler036.IsPalindromeInBothBases(input);

        result.Should().Be(expected);
    }
}