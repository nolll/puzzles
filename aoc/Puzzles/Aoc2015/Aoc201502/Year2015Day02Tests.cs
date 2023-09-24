using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day02;

public class Year2015Day02Tests
{
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void CorrectSquareFeetForSingleGift(string input, int expected)
    {
        var result = GiftWrappingCalculator.GetRequiredPaperForOneBox(input);

        Assert.That(result, Is.EqualTo(expected));
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

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void CorrectRibbonLength(string input, int expected)
    {
        var result = GiftWrappingCalculator.GetRequiredRibbonForOneBox(input);

        Assert.That(result, Is.EqualTo(expected));
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

        Assert.That(result, Is.EqualTo(expected));
    }
}