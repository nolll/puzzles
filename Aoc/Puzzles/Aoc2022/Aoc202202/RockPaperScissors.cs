using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public class RockPaperScissors
{
    public int Part1(string input)
    {
        return StringReader
            .ReadLines(input, false)
            .Select(Part1Round.Parse).Sum(o => o.Score);
    }

    public int Part2(string input)
    {
        return StringReader
            .ReadLines(input, false)
            .Select(Part2Round.Parse).Sum(o => o.Score);
    }
}