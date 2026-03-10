using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202201;

[Name("Calorie Counting")]
public class Aoc202201 : AocPuzzle
{
    [Puzzle("81d10392efffeffbb6e17e0d97cffb22")]
    public int Part1(string input) => ParseSums(input).Max();

    [Puzzle("f7b7d38797d430f1b611936533333c26")]
    public int Part2(string input) => ParseSums(input).OrderByDescending(o => o).Take(3).Sum();

    private static IEnumerable<int> ParseSums(string input) => input
        .Split(LineBreaks.Double)
        .Select(o => o.Split(LineBreaks.Single))
        .Select(o => o.Sum(int.Parse));
}