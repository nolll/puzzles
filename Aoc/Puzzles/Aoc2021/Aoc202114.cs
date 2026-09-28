using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

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
    
    public static class CountMerger
    {
        public static Dictionary<char, long> MergeCounts(params Dictionary<char, long>[] dictionaries)
        {
            var merged = new Dictionary<char, long>();
            foreach (var dictionary in dictionaries)
            {
                foreach (var key in dictionary.Keys)
                {
                    merged.TryAdd(key, 0);
                    merged[key] += dictionary[key];
                }
            }

            return merged;
        }
    }
    
    public class PolymerCombination(Dictionary<(char, char), char> rules, char a, char b, int level, int maxLevel)
    {
        public Dictionary<char, long> CountsChars(Dictionary<(char, char, int), Dictionary<char, long>> cache)
        {
            var cacheKey = (_a: a, _b: b, _level: level);
            if (cache.TryGetValue(cacheKey, out var chars))
                return chars;

            var counts = new Dictionary<char, long>();

            if (level < maxLevel)
            {
                var insert = rules[(a, b)];
                var left = new PolymerCombination(rules, a, insert, level + 1, maxLevel);
                var right = new PolymerCombination(rules, insert, b, level + 1, maxLevel);
                var leftCounts = left.CountsChars(cache);
                var rightCounts = right.CountsChars(cache);
                counts = CountMerger.MergeCounts(counts, leftCounts, rightCounts);
            }
            else
            {
                Increment(counts, a);
            }

            cache.Add(cacheKey, counts);
            return counts;
        }

        private static void Increment(IDictionary<char, long> counts, char c)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }
    }
}