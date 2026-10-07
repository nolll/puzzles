using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201801Tests : PuzzleTest<Aoc201801>
{
    [Theory]
    [InlineData("-1", -1)]
    [InlineData("+1", 1)]
    [InlineData("-1 +2", 1)]
    [InlineData("+1 +1 +1", 3)]
    [InlineData("+1 +1 -2", 0)]
    [InlineData("-1 -2 -3", -6)]
    public void HandleProvidedPart1Examples(string changes, int expected) => 
        Sut.Part1(SpacesToNewLines(changes)).Should().Be(expected);

    [Theory]
    [InlineData("+1 -1", 0)]
    [InlineData("+3 +3 +4 -2 -4", 10)]
    [InlineData("-6 +3 +8 +5 -6", 5)]
    [InlineData("+7 +7 -2 -7 -4", 14)]
    public void HandleProvidedPart2Examples(string changes, int expected) => 
        Sut.Part2(SpacesToNewLines(changes)).Should().Be(expected);
}