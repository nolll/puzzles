using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler031;

[Name("Coin sums")]
public class Euler031 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var denominations = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
        const int targetSum = 200;

        var result = Run(denominations, targetSum);

        return new PuzzleResult(result, "7175474dc7b139b075af256e2253a076");
    }

    public int Run(IEnumerable<int> denominations, int target) => 
        CountCombinations(denominations.OrderByDescending(o => o).ToList(), target);

    private static int CountCombinations(IReadOnlyCollection<int> denominations, int target)
    {
        if (target < 0 || !denominations.Any())
            return 0;

        if (target == 0)
            return 1;

        var count = 0;
        var denomination = denominations.First();
        var remainingDenominations = denominations.Skip(1).ToList();

        count += CountCombinations(denominations, target - denomination);
        count += CountCombinations(remainingDenominations, target);

        return count;
    }
}
