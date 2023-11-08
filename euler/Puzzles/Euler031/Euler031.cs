using Common.Puzzles;

namespace Euler.Puzzles.Euler031;

public class Euler031 : EulerPuzzle
{
    public override string Name => "Coin sums";

    protected override PuzzleResult Run()
    {
        var denominations = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
        const int targetSum = 200;

        var result = Run(denominations, targetSum);

        return new PuzzleResult(result, "142dfe4a33d624d2b830a9257e96726d");
    }

    public int Run(IEnumerable<int> denominations, int target, bool print = false)
    {
        var count = CountCombinations(denominations.OrderByDescending(o => o).ToList(), target, "", print);

        return count;
    }

    private static int CountCombinations(IReadOnlyCollection<int> denominations, int target, string str, bool print)
    {
        if (target < 0 || !denominations.Any())
            return 0;

        if (target == 0)
        {
            if(print)
                Console.WriteLine(str);

            return 1;
        }

        var count = 0;
        var denomination = denominations.First();
        var remainingDenominations = denominations.Skip(1).ToList();

        count += CountCombinations(denominations, target - denomination, $"{str}{denomination}, ", print);
        count += CountCombinations(remainingDenominations, target, str, print);

        return count;
    }
}
