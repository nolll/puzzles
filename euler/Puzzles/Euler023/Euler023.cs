using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler023;

public class Euler023 : EulerPuzzle
{
    private const int UpperLimit = 28123;

    public override string Name => "Non-abundant sums";

    protected override PuzzleResult Run()
    {
        var abundantNumbers = FindAbundantNumbers(UpperLimit).ToList();
        var sumsOfAbundantNumbers = GetSums(abundantNumbers);

        var sum = 0;
        for (var i = 0; i < UpperLimit; i++)
        {
            if (!sumsOfAbundantNumbers.Contains(i))
                sum += i;
        }
            
        return new PuzzleResult(sum, "2c8258c0604152962f7787571511cf28");
    }

    private static HashSet<int> GetSums(List<int> abundantNumbers)
    {
        var sums = new HashSet<int>();
        foreach (var outer in abundantNumbers)
        {
            foreach (var inner in abundantNumbers)
            {
                var sum = inner + outer;
                if (sum < 28123 && !sums.Contains(sum))
                    sums.Add(sum);
            }
        }

        return sums;
    }

    public static IEnumerable<int> FindAbundantNumbers(int upperLimit)
    {
        for (var i = 12; i <= upperLimit; i++)
        {
            var divisors = Numbers.GetProperDivisors(i);
            var sum = divisors.Sum();
            if(sum > i)
                yield return i;
        }
    }
}