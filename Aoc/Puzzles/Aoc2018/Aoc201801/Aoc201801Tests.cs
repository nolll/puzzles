using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201801;

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
        const string changes = "-1 +2";
        var puzzle = new FrequencyPuzzle(SpacesToNewLines(changes));
        puzzle.ResultingFrequency.Should().Be(1);
    }

    [TestCase("+1 +1 +1", 3)]
    [TestCase("+1 +1 -2", 0)]
    [TestCase("-1 -2 -3", -6)]
    public void HandleProvidedPart1Examples(string changes, int expected)
    {
        var puzzle = new FrequencyPuzzle(SpacesToNewLines(changes));
        puzzle.ResultingFrequency.Should().Be(expected);
    }

    [TestCase("+1 -1", 0)]
    [TestCase("+3 +3 +4 -2 -4", 10)]
    [TestCase("-6 +3 +8 +5 -6", 5)]
    [TestCase("+7 +7 -2 -7 -4", 14)]
    public void HandleProvidedPart2Examples(string changes, int expected)
    {
        var puzzle = new FrequencyRepeatPuzzle(SpacesToNewLines(changes));
        puzzle.FirstRepeatedFrequency.Should().Be(expected);
    }

    private string SpacesToNewLines(string input) => input.Replace(" ", Environment.NewLine);
}