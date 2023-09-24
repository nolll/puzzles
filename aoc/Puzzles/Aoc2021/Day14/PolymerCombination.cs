using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2021.Day14;

public class PolymerCombination
{
    private readonly char _a;
    private readonly char _b;
    private readonly int _level;
    private readonly int _maxLevel;
    private readonly Dictionary<(char, char), char> _rules;

    public PolymerCombination(Dictionary<(char, char), char> rules, char a, char b, int level, int maxLevel)
    {
        _rules = rules;
        _a = a;
        _b = b;
        _level = level;
        _maxLevel = maxLevel;
    }

    public Dictionary<char, long> CountsChars(Dictionary<(char, char, int), Dictionary<char, long>> cache)
    {
        var cacheKey = (_a, _b, _level);
        if (cache.ContainsKey(cacheKey))
            return cache[cacheKey];

        var counts = new Dictionary<char, long>();

        if (_level < _maxLevel)
        {
            var insert = _rules[(_a, _b)];
            var left = new PolymerCombination(_rules, _a, insert, _level + 1, _maxLevel);
            var right = new PolymerCombination(_rules, insert, _b, _level + 1, _maxLevel);
            var leftCounts = left.CountsChars(cache);
            var rightCounts = right.CountsChars(cache);
            counts = CountMerger.MergeCounts(counts, leftCounts, rightCounts);
        }
        else
        {
            Increment(counts, _a);
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