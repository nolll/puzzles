using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201801;

public class Aoc201801Tests
{
    [Test]
    public void HandleOneNegativeChange()
    {
        const string changes = "-1";
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(-1);
    }

    [Test]
    public void HandleOnePositiveChange()
    {
        const string changes = "+1";
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(1);
    }

    [Test]
    public void HandleTwoChanges()
    {
        const string changes = "-1\n+2";
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(1);
    }

    [TestCase("+1\n+1\n+1", 3)]
    [TestCase("+1\n+1\n-2", 0)]
    [TestCase("-1\n-2\n-3", -6)]
    public void HandleProvidedPart1Examples(string changes, int expected)
    {
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(expected);
    }

    [TestCase("+1\n-1", 0)]
    [TestCase("+3\n+3\n+4\n-2\n-4", 10)]
    [TestCase("-6\n+3\n+8\n+5\n-6", 5)]
    [TestCase("+7\n+7\n-2\n-7\n-4", 14)]
    public void HandleProvidedPart2Examples(string changes, int expected)
    {
        var puzzle = new FrequencyRepeatPuzzle(changes);
        puzzle.FirstRepeatedFrequency.Should().Be(expected);
    }
}