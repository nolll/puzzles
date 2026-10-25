using Pzl.Common;
using Pzl.Tools.Combinatorics;

namespace Pzl.Aquaq.Puzzles;

[Name("Bit of Bully")]
public class Aquaq33 : AquaqPuzzle
{
    [Puzzle("3c08f90044660194d3d619fa4c14d736")]
    public long Solve() => Run(245701);

    public long Run(int maxTarget)
    {
        var dartCounts = GetDartCounts();
        var sum = 0L;
        for (var i = 1; i <= maxTarget; i++)
        {
            sum += Play(dartCounts, i);
        }

        return sum;
    }

    public int Play(int remaining) => Play(GetDartCounts(), remaining);

    private int Play(Dictionary<int, int> dartCounts, int remaining)
    {
        var bulkCount = PlayMaxScores(remaining);
        remaining -= bulkCount * MaxScore;
        return bulkCount + dartCounts[remaining];
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

    public Dictionary<int, int> GetDartCounts()
    {
        var comboCache = new Dictionary<int, IList<IList<int>>>();
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
                if (!comboCache.TryGetValue(comboLength, out var combos))
                {
                    combos = [.. CombinationGenerator.GetCombinationsFixedSize([.. _allScores], comboLength)];
                    comboCache.Add(comboLength, combos);
                }

                var matchingCombos = combos.Where(o => o.Sum() == i).ToList();
                if (matchingCombos.Count != 0)
                {
                    dartCounts.Add(i, comboLength);
                    break;
                }

                comboLength++;
            }
        }

        return dartCounts;
    }
    
    private const int MaxScore = 60;

    private readonly HashSet<int> _allScores =
    [
        .. SingleScores,
        .. DoubleScores,
        .. TripleScores,
        .. BullScores,
    ];

    private static IEnumerable<int> SingleScores => ScoreSequence(1, 20);
    private static IEnumerable<int> DoubleScores => ScoreSequence(2, 40);
    private static IEnumerable<int> TripleScores => ScoreSequence(3, 60);
    private static IEnumerable<int> BullScores => ScoreSequence(25, 50);
    private static IEnumerable<int> ScoreSequence(int step, int max) => Enumerable.Sequence(step, max, step);
}