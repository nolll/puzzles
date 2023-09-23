using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler003;

public class Euler003 : EulerPuzzle
{
    public override string Name => "Largest prime factor";

    protected override PuzzleResult Run()
    {
        var largestPrime = Run(600_851_475_143);
            
        return new PuzzleResult(largestPrime, 6857);
    }

    public long Run(long number)
    {
        return Numbers.FindLargestPrimeFactor(number);
    }
}