using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

[Name("Extended Polymerization")]
public class Aoc202114 : AocPuzzle
{
    [Puzzle("1efc37e1defc93f45f72522371cce05c")]
    public long Part1(string input) => Solve(input, 10);

    [Puzzle("d36de0cab46393825975a1adaea40dc4")]
    public long Part2(string input) => Solve(input, 40);
    
    public long Solve(string input, int stepCount)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .ToList();

        var rules = new Dictionary<(char, char), char>();
        foreach (var strRule in groups[1])
        {
            var parts = strRule.Split(" -> ");
            var arr = parts[0].ToCharArray();
            rules.Add((arr[0], arr[1]), parts[1].ToCharArray().First());
        }

        var cache = new Dictionary<(char, char, int), Dictionary<char, long>>();
        var chars = groups[0].First().ToCharArray();
        var lastChar = chars.Last();
        var countList = new List<Dictionary<char, long>>();
        for (var i = 1; i < chars.Length; i++)
        {
            var a = chars[i - 1];
            var b = chars[i];
            var combination = new PolymerCombination(rules, a, b, 0, stepCount);
            countList.Add(combination.CountsChars(cache));
        }

        var counts = CountMerger.MergeCounts(countList.ToArray());
        counts[lastChar]++;

        var min = counts.Values.Min();
        var max = counts.Values.Max();

        return max - min;
    }
}