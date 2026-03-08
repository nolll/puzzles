using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201610;

[Name("Balance Bots")]
public class Aoc201610 : AocPuzzle
{
    [Puzzle("5141409a7397bcdc4bb364bbb1ea2965")]
    public int Part1(string input) => new BotSimulator(input).FindIdByChips(17, 61);

    [Puzzle("1e81841d2042e89e46105118a32aee33")]
    public int Part2(string input) => new BotSimulator(input).GetMultipliedOutput();
}