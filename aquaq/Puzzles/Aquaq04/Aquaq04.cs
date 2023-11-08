using Common.Numbers;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq04;

public class Aquaq04 : AquaqPuzzle
{
    public override string Name => "This is good co-primen";

    private const int Input = 987820;

    protected override PuzzleResult Run()
    {
        var sum = FindCoPrimesFor(Input).Sum();
        return new PuzzleResult(sum, "5685346224793e2dfcb239f67bf4010f");
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