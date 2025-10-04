namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201709;

public class Aoc201709Tests
{
    [Theory]
    [InlineData("{}", "{}", 1, 1)]
    [InlineData("{{{}}}", "{{{}}}", 3, 6)]
    [InlineData("{{},{}}", "{{},{}}", 3, 5)]
    [InlineData("{{{},{},{{}}}}", "{{{},{},{{}}}}", 6, 16)]
    [InlineData("{<{},{},{{}}>}", "{}", 1, 1)]
    [InlineData("{<a>,<a>,<a>,<a>}", "{,,,}", 1, 1)]
    [InlineData("{{<a>},{<a>},{<a>},{<a>}}", "{{},{},{},{}}", 5, 9)]
    [InlineData("{{<!>},{<!>},{<!>},{<a>}}", "{{}}", 2, 3)]
    [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", "{{},{},{},{}}", 5, 9)]
    public void GroupCountAndScoreIsCorrect(string input, string expectedCleaned, int expectedCount, int expectedScore)
    {
        var processor = new StreamProcessor(input);

        processor.Cleaned.Should().Be(expectedCleaned);
        processor.GroupCount.Should().Be(expectedCount);
        processor.Score.Should().Be(expectedScore);
    }

    [Theory]
    [InlineData("{<>}", 0)]
    [InlineData("{<random characters>}", 17)]
    [InlineData("{<<<<>}", 3)]
    [InlineData("{<{!>}>}", 2)]
    [InlineData("{<!!>}", 0)]
    [InlineData("{<!!!>>}", 0)]
    [InlineData("{<{o\"i!a,<{i<a>}", 10)]
    public void GarbageCountIsCorrect(string input, int expected)
    {
        var processor = new StreamProcessor(input);

        processor.GarbageCount.Should().Be(expected);
    }
}