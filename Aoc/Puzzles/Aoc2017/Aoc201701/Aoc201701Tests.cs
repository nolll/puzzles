namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201701;

public class Aoc201701Tests
{
    [Theory]
    [InlineData("1122", 3)]
    [InlineData("1111", 4)]
    [InlineData("1234", 0)]
    [InlineData("91212129", 9)]
    public void CorrectSumOfMatchingNumbers_Sum1(string input, int sum)
    {
        var captcha = new CaptchaCalculator(input);

        captcha.Sum1.Should().Be(sum);
    }

    [Theory]
    [InlineData("1212", 6)]
    [InlineData("1221", 0)]
    [InlineData("123425", 4)]
    [InlineData("123123", 12)]
    [InlineData("12131415", 4)]
    public void CorrectSumOfMatchingNumbers_Sum2(string input, int sum)
    {
        var captcha = new CaptchaCalculator(input);

        captcha.Sum2.Should().Be(sum);
    }
}