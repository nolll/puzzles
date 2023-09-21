using System.Linq;
using common.Strings;

namespace Aoc.Puzzles.Year2022.Day02;

public class RockPaperScissors
{
    public int Part1(string input)
    {
        return PuzzleInputReader
            .ReadLines(input, false)
            .Select(Part1Round.Parse).Sum(o => o.Score);
    }

    public int Part2(string input)
    {
        return PuzzleInputReader
            .ReadLines(input, false)
            .Select(Part2Round.Parse).Sum(o => o.Score);
    }
}