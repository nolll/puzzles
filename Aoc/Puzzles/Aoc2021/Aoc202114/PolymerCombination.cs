namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

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