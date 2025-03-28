using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201701;

public class Aoc201701Tests
{
    [TestCase("1122", 3)]
    [TestCase("1111", 4)]
    [TestCase("1234", 0)]
    [TestCase("91212129", 9)]
    public void CorrectSumOfMatchingNumbers_Sum1(string input, int sum)
    {
        var captcha = new CaptchaCalculator(input);

        captcha.Sum1.Should().Be(sum);
    }

    [TestCase("1212", 6)]
    [TestCase("1221", 0)]
    [TestCase("123425", 4)]
    [TestCase("123123", 12)]
    [TestCase("12131415", 4)]
    public void CorrectSumOfMatchingNumbers_Sum2(string input, int sum)
    {
        var captcha = new CaptchaCalculator(input);

        captcha.Sum2.Should().Be(sum);
    }
}