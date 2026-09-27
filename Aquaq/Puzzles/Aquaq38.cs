using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Number Neighbours")]
public class Aquaq38 : AquaqPuzzle
{
    [Puzzle("56082eb21bc29c4cc0607606e3d88ddd")]
    public int Solve(string input) => input.Split(LineBreaks.Single)
        .Select(o => o.Split(' ').Select(int.Parse).ToArray())
        .Sum(o => GetComfScore(new IndexStreakProvider(), o));

    public static int GetComfScore(IndexStreakProvider indexStreakProvider, int[] a)
    {
        var allIndexStreaks = indexStreakProvider.Get(a);
        var score = 0;

        for (var i = 0; i < a.Length; i++)
        {
            var streaks = allIndexStreaks[i];
            var groupedStreaks = streaks.GroupBy(o => o.Length).OrderBy(o => o.Key);

            var streakOfStreaks = 0;
            var longestStreakOfStreaks = 0;
            foreach (var groupedStreak in groupedStreaks)
            {
                var hasCosyStreak = groupedStreak.Any(o => IsCosy(groupedStreak.Key, a, o));
                if (hasCosyStreak)
                    streakOfStreaks++;
                else
                    break;
                longestStreakOfStreaks = Math.Max(streakOfStreaks, longestStreakOfStreaks);
            }

            score += longestStreakOfStreaks;
        }

        return score;
    }

    private static bool IsCosy(int length, int[] a, int[] indices) => GetStreakSum(a, indices) % length == 0;
    private static int GetStreakSum(int[] a, int[] indices) => indices.Sum(index => a[index]);
    
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
}