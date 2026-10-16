using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Custom Customs")]
public class Aoc202006 : AocPuzzle
{
    [Puzzle("15504e0b1c6cbf2a51c9cae0ce1a7ec1")]
    public int Part1(string input) => Parse(input).Sum(GetLettersWithAtLeastOneYes);

    [Puzzle("68cdb9b46ee8ea4505031a144aef81d2")]
    public int Part2(string input) => Parse(input).Sum(GetLettersWithAllYes);

    private static int GetLettersWithAtLeastOneYes(string[] group) =>
        string.Concat(group).Distinct().Order().Count();

    private static int GetLettersWithAllYes(string[] group)
    {
        var allAnswers = string.Concat(group);
        return allAnswers.Distinct().Order().Count(o => allAnswers.Count(c => c == o) == group.Length);
    }

    private static IEnumerable<string[]> Parse(string input) => input
        .Split(LineBreaks.Double).Select(o => o.Split(LineBreaks.Single));
}