using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public class RockPaperScissors
{
    public int Part1(string input) => Solve(input, Part1Round.Parse);

    public int Part2(string input) => Solve(input, Part2Round.Parse);

    private static int Solve(string input, Func<string, RockPaperScissorsRound> parse) => input.Split(LineBreaks.Single)
        .Where(o => o.Length > 0)
        .Select(parse)
        .Sum(o => o.Score);
}