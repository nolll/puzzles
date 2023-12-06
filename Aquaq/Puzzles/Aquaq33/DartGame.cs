using Pzl.Tools.Combinatorics;

namespace Pzl.Aquaq.Puzzles.Aquaq33;

public class DartGame
{
    private const int MaxScore = 60;

    private readonly HashSet<int> _allScores = new[]
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60,
        25, 50
    }.ToHashSet();

    private readonly Dictionary<int, int> _dartCounts;
    private readonly Dictionary<int, IList<IList<int>>> _comboCache = new();

    public DartGame()
    {
        _dartCounts = GetDartCounts();
    }

    public int Play(int remaining)
    {
        var bulkCount = PlayMaxScores(remaining);
        remaining -= bulkCount * MaxScore;
        return bulkCount + _dartCounts[remaining];
    }

    private static int PlayMaxScores(int target)
    {
        var sixtyCount = 0;
        while (target > MaxScore * 3)
        {
            sixtyCount += 1;
            target -= MaxScore;
        }

        return sixtyCount;
    }

    private Dictionary<int, int> GetDartCounts()
    {
        var dartCounts = new Dictionary<int, int> { { 0, 0 } };
        for (var i = 1; i <= MaxScore * 3; i++)
        {
            if (_allScores.Contains(i))
            {
                dartCounts.Add(i, 1);
                continue;
            }

            var comboLength = 2;
            while (comboLength < 10)
            {
                if (!_comboCache.TryGetValue(comboLength, out var combos))
                {
                    combos = CombinationGenerator.GetCombinationsFixedSize(_allScores.ToList(), comboLength).ToList();
                    _comboCache.Add(comboLength, combos);
                }
                var matchingCombos = combos.Where(o => o.Sum() == i).ToList();
                if (matchingCombos.Any())
                {
                    dartCounts.Add(i, comboLength);
                    break;
                }

                comboLength++;
            }
        }

        return dartCounts;
    }
}