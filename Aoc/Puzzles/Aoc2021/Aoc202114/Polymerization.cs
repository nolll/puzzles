using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

public class Polymerization
{
    public long Run(string input, int stepCount)
    {
        var groups = StringReader.ReadLineGroups(input);

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