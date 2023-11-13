using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2017.Aoc201709;

public class Aoc201709Tests
{
    [TestCase("{}", "{}", 1, 1)]
    [TestCase("{{{}}}", "{{{}}}", 3, 6)]
    [TestCase("{{},{}}", "{{},{}}", 3, 5)]
    [TestCase("{{{},{},{{}}}}", "{{{},{},{{}}}}", 6, 16)]
    [TestCase("{<{},{},{{}}>}", "{}", 1, 1)]
    [TestCase("{<a>,<a>,<a>,<a>}", "{,,,}", 1, 1)]
    [TestCase("{{<a>},{<a>},{<a>},{<a>}}", "{{},{},{},{}}", 5, 9)]
    [TestCase("{{<!>},{<!>},{<!>},{<a>}}", "{{}}", 2, 3)]
    [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", "{{},{},{},{}}", 5, 9)]
    public void GroupCountAndScoreIsCorrect(string input, string expectedCleaned, int expectedCount, int expectedScore)
    {
        var processor = new StreamProcessor(input);

        processor.Cleaned.Should().Be(expectedCleaned);
        processor.GroupCount.Should().Be(expectedCount);
        processor.Score.Should().Be(expectedScore);
    }

    [TestCase("{<>}", 0)]
    [TestCase("{<random characters>}", 17)]
    [TestCase("{<<<<>}", 3)]
    [TestCase("{<{!>}>}", 2)]
    [TestCase("{<!!>}", 0)]
    [TestCase("{<!!!>>}", 0)]
    [TestCase("{<{o\"i!a,<{i<a>}", 10)]
    public void GarbageCountIsCorrect(string input, int expected)
    {
        var processor = new StreamProcessor(input);

        processor.GarbageCount.Should().Be(expected);
    }
}