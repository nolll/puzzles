using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201502;

public class Aoc201502Tests
{
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void CorrectSquareFeetForSingleGift(string input, int expected)
    {
        var result = GiftWrappingCalculator.GetRequiredPaperForOneBox(input);

        result.Should().Be(expected);
    }

    [Test]
    public void CorrectSquareFeetForMultipleGifts()
    {
        const string input = """
2x3x4
1x1x10
""";
        const int expected = 101;

        var result = GiftWrappingCalculator.GetRequiredPaper(input);

        result.Should().Be(expected);
    }

    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void CorrectRibbonLength(string input, int expected)
    {
        var result = GiftWrappingCalculator.GetRequiredRibbonForOneBox(input);

        result.Should().Be(expected);
    }

    [Test]
    public void CorrectRibbonLengthForMultipleGifts()
    {
        const string input = """
2x3x4
1x1x10
""";
        const int expected = 48;

        var result = GiftWrappingCalculator.GetRequiredRibbon(input);

        result.Should().Be(expected);
    }
}