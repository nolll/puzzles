using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201510;

[Name("Elves Look, Elves Say")]
public class Aoc201510 : AocPuzzle
{
    [Puzzle("1c32a9d4af561a5e8468442397ce06c0")]
    public int Part1(string input) => new LookAndSayGame(input, 40).Result.Length;

    [Puzzle("f96f3f93bd5cbf8f3cf1bcf814ba4707")]
    public int Part2(string input) => new LookAndSayGame(input, 50).Result.Length;
}