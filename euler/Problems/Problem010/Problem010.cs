using Common.Numbers;
using Common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem010;

public class Problem010 : EulerPuzzle
{
    public override string Name => "Summation of primes";

    public override PuzzleResult Run()
    {
        var result = Run(2_000_000);
        return new PuzzleResult(result, 142913828922);
    }

    public long Run(int limit)
    {
        var primes = Numbers.FindPrimesBelow(limit);

        return primes.Aggregate<int, long>(0, (current, p) => current + p);
    }
}