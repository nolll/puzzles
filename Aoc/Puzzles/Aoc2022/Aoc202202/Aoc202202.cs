using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

[Name("Rock Paper Scissors")]
public class Aoc202202 : AocPuzzle
{
    [Puzzle("21342a8c13c83a2420368dd586a7a5dd")]
    public int Part1(string input) => Solve(input, Part1Round.Parse);

    [Puzzle("ee182ab67d32eeac3499142ceeb632c3")]
    public int Part2(string input) => Solve(input, Part2Round.Parse);

    private static int Solve(string input, Func<string, RockPaperScissorsRound> parse) =>
        input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(parse)
            .Sum(o => o.Score);
}