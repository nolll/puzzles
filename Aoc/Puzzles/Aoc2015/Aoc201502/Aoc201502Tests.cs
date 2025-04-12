using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201502;

public class Aoc201502Tests
{
    private const string MultipleInput = """
                                         2x3x4
                                         1x1x10
                                         """;

    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void CorrectSquareFeetForSingleGift(string input, int expected) => 
        Sut.GetRequiredPaperForOneBox(input).Should().Be(expected);

    [Test]
    public void CorrectSquareFeetForMultipleGifts() => Sut.Part1(MultipleInput).Answer.Should().Be("101");

    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void CorrectRibbonLength(string input, int expected) => 
        Sut.GetRequiredRibbonForOneBox(input).Should().Be(expected);

    [Test]
    public void CorrectRibbonLengthForMultipleGifts() => Sut.Part2(MultipleInput).Answer.Should().Be("48");

    private static Aoc201502 Sut => new();
}