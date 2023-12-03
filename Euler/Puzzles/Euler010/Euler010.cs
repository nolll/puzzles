using Puzzles.Common.Numbers;
using Puzzles.Common.Puzzles;

namespace Puzzles.Euler.Puzzles.Euler010;

public class Euler010 : EulerPuzzle
{
    public override string Name => "Summation of primes";

    protected override PuzzleResult Run()
    {
        var result = Run(2_000_000);
        return new PuzzleResult(result, "91e6ee4eecd36e3d7d1278ed37721706");
    }

    public long Run(int limit)
    {
        var primes = Numbers.FindPrimesBelow(limit);

        return primes.Aggregate<int, long>(0, (current, p) => current + p);
    }
}