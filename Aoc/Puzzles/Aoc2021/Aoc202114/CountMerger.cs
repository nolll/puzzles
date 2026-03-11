namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202114;

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