using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq38;

[Name("Number Neighbours")]
public class Aquaq38(string input) : AquaqPuzzle(input)
{
    protected override PuzzleResult Run()
    {
        var indexStreakProvider = new IndexStreakProvider();
        var lists = StringReader.ReadLines(Input)
            .Select(o => o.Split(' ').Select(int.Parse).ToArray()).ToList();
        var sum = lists.Sum(o => GetComfScore(indexStreakProvider, o));

        return new PuzzleResult(sum, "56082eb21bc29c4cc0607606e3d88ddd");
    }

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

    private static bool IsCosy(int length, int[] a, int[] indices) 
        => GetStreakSum(a, indices) % length == 0;

    private static int GetStreakSum(int[] a, int[] indices)
        => indices.Sum(index => a[index]);
}