using Puzzles.common.Numbers;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq04;

public class Aquaq04 : AquaqPuzzle
{
    public override string Name => "This is good co-primen";

    private const int Input = 987820;

    protected override PuzzleResult Run()
    {
        var sum = FindCoPrimesFor(Input).Sum();
        return new PuzzleResult(sum, "7a296f6d92cf29d6ec3b4e51af411018");
    }

    public static IEnumerable<long> FindCoPrimesFor(int n)
    {
        var nFactors = FindDivisors(n);
        for (var i = 1; i < n; i++)
        {
            var factors = FindDivisors(i);
            var isOverlapping = factors.Overlaps(nFactors);
            if (!isOverlapping)
                yield return i;
        }
    }

    private static HashSet<int> FindDivisors(int n)
    {
        return Numbers.GetAllDivisors(n)
            .Where(o => o > 1)
            .ToHashSet();
    }
}