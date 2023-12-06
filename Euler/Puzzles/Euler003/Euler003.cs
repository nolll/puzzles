using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler003;

public class Euler003 : EulerPuzzle
{
    public override string Name => "Largest prime factor";

    protected override PuzzleResult Run()
    {
        var largestPrime = Run(600_851_475_143);
            
        return new PuzzleResult(largestPrime, "bc05f2cc254574e3679f0a25c811dea1");
    }

    public long Run(long number)
    {
        return Numbers.FindLargestPrimeFactor(number);
    }
}