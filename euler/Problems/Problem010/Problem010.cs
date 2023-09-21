using common.Numbers;
using Euler.Platform;

namespace Euler.Problems.Problem010;

public class Problem010 : EulerPuzzle
{
    public override string Name => "Summation of primes";
        
    public override ProblemResult Run()
    {
        var result = Run(2_000_000);
        return new ProblemResult(result, 142913828922);
    }

    public long Run(int limit)
    {
        var primes = Numbers.FindPrimesBelow(limit);

        return primes.Aggregate<int, long>(0, (current, p) => current + p);
    }
}