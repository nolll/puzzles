using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

public class Aoc201801Tests
{
    [Fact]
    public void HandleOneNegativeChange()
    {
        const string changes = "-1";
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(-1);
    }

    [Fact]
    public void HandleOnePositiveChange()
    {
        const string changes = "+1";
        var puzzle = new FrequencyPuzzle(changes);
        puzzle.ResultingFrequency.Should().Be(1);
    }

    [Fact]
    public void HandleTwoChanges()
    {
        const string changes = "-1 +2";
        var puzzle = new FrequencyPuzzle(SpacesToNewLines(changes));
        puzzle.ResultingFrequency.Should().Be(1);
    }

    [Theory]
    [InlineData("+1 +1 +1", 3)]
    [InlineData("+1 +1 -2", 0)]
    [InlineData("-1 -2 -3", -6)]
    public void HandleProvidedPart1Examples(string changes, int expected)
    {
        var puzzle = new FrequencyPuzzle(SpacesToNewLines(changes));
        puzzle.ResultingFrequency.Should().Be(expected);
    }

    [Theory]
    [InlineData("+1 -1", 0)]
    [InlineData("+3 +3 +4 -2 -4", 10)]
    [InlineData("-6 +3 +8 +5 -6", 5)]
    [InlineData("+7 +7 -2 -7 -4", 14)]
    public void HandleProvidedPart2Examples(string changes, int expected)
    {
        var puzzle = new FrequencyRepeatPuzzle(SpacesToNewLines(changes));
        puzzle.FirstRepeatedFrequency.Should().Be(expected);
    }

    private string SpacesToNewLines(string input) => input.Replace(" ", LineBreaks.Single);
}