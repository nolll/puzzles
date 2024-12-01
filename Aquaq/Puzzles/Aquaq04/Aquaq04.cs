using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aquaq.Puzzles.Aquaq04;

[Name("This is good co-primen")]
public class Aquaq04 : AquaqPuzzle
{
    public PuzzleResult Run(string input)
    {
        var sum = FindCoPrimesFor(int.Parse(input)).Sum();
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