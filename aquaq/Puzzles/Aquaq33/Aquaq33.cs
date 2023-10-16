using Common.Combinatorics;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq33;

public class Aquaq33 : AquaqPuzzle
{
    private const int MaxScore = 60;

    private static readonly HashSet<int> AllScores = new[]
    {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
        2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40,
        3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60,
        25, 50
    }.ToHashSet();

    private static readonly Dictionary<int, int> DartCounts = GetDartCounts();

    public override string Name => "Bit of Bully";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(245701));
    }

    public static long Run(int maxTarget)
    {
        var sum = 0L;
        for (var i = 1; i <= maxTarget; i++)
        {
            sum += Play(i);
        }

        return sum;
    }

    private static Dictionary<int, int> GetDartCounts()
    {
        var dartCounts = new Dictionary<int, int>();
        for (var i = 1; i <= MaxScore * 3; i++)
        {
            if (AllScores.Contains(i))
            {
                dartCounts.Add(i, 1);
                continue;
            }

            var comboLength = 2;
            while (comboLength < 10)
            {
                var combos = CombinationGenerator.GetUniqueCombinationsFixedSize(AllScores.ToList(), comboLength);
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

    public static int Play(int target)
    {
        var maxScoreCount = target / (MaxScore * 3);
        var remainder = target % (MaxScore * 3);
        var remainderDartCount = remainder > 0 ? DartCounts[remainder] : 0;
        return maxScoreCount * 3 + remainderDartCount;
    }
}