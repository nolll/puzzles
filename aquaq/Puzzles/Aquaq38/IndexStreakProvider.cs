namespace Puzzles.Aquaq.Puzzles.Aquaq38;

public class IndexStreakProvider
{
    private readonly Dictionary<int, int[][][]> _cache = new();

    public int[][][] Get(int[] a)
    {
        if (_cache.TryGetValue(a.Length, out var cached))
            return cached;

        var allStreaks = new List<int[][]>();
        for (var pos = 0; pos < a.Length; pos++)
        {
            var streaks = new List<int[]>();
            for (var start = 0; start <= pos; start++)
            {
                for (var end = pos; end < a.Length; end++)
                {
                    streaks.Add(Enumerable.Range(start, end - start + 1).ToArray());
                }
            }
            allStreaks.Add(streaks.ToArray());
        }

        var allStreaksArray = allStreaks.ToArray();
        _cache.Add(a.Length, allStreaksArray);
        return allStreaksArray;
    }
}