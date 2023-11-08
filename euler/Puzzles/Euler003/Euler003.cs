using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler003;

public class Euler003 : EulerPuzzle
{
    public override string Name => "Largest prime factor";

    protected override PuzzleResult Run()
    {
        var largestPrime = Run(600_851_475_143);
            
        return new PuzzleResult(largestPrime, "94c4dd41f9dddce696557d3717d98d82");
    }

    public long Run(long number)
    {
        return Numbers.FindLargestPrimeFactor(number);
    }
}