using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201709Tests : PuzzleTest<Aoc201709>
{
    [Theory]
    [InlineData("{}", 1)]
    [InlineData("{{{}}}", 6)]
    [InlineData("{{},{}}", 5)]
    [InlineData("{{{},{},{{}}}}", 16)]
    [InlineData("{<{},{},{{}}>}", 1)]
    [InlineData("{<a>,<a>,<a>,<a>}", 1)]
    [InlineData("{{<a>},{<a>},{<a>},{<a>}}", 9)]
    [InlineData("{{<!>},{<!>},{<!>},{<a>}}", 3)]
    [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
    public void Part1(string input, int expected)
    {
        var (score, _) = Sut.Solve(input);
        score.Should().Be(expected);
    }

    [Theory]
    [InlineData("{<>}", 0)]
    [InlineData("{<random characters>}", 17)]
    [InlineData("{<<<<>}", 3)]
    [InlineData("{<{!>}>}", 2)]
    [InlineData("{<!!>}", 0)]
    [InlineData("{<!!!>>}", 0)]
    [InlineData("{<{o\"i!a,<{i<a>}", 10)]
    public void Part2(string input, int expected)
    {
        var (_, cleaned) = Sut.Solve(input);
        cleaned.Should().Be(expected);
    }
}