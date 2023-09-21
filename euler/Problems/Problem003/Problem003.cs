using common.Numbers;
using common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem003;

public class Problem003 : EulerPuzzle
{
    public override string Name => "Largest prime factor";

    public override PuzzleResult Run()
    {
        var largestPrime = Run(600_851_475_143);
            
        return new PuzzleResult(largestPrime, 6857);
    }

    public long Run(long number)
    {
        return Numbers.FindLargestPrimeFactor(number);
    }
}