using NUnit.Framework;

namespace Core.Puzzles.Year2015.Day02;

public class Year2015Day02Tests
{
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void CorrectSquareFeetForSingleGift(string input, int expected)
    {
        var calc = new GiftWrappingCalculator();
        var result = calc.GetRequiredPaperForOneBox(input);

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

        var calc = new GiftWrappingCalculator();
        var result = calc.GetRequiredPaper(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void CorrectRibbonLength(string input, int expected)
    {
        var calc = new GiftWrappingCalculator();
        var result = calc.GetRequiredRibbonForOneBox(input);

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

        var calc = new GiftWrappingCalculator();
        var result = calc.GetRequiredRibbon(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}