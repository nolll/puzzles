using Euler.Common.Numbers;
using Euler.Platform;

namespace Euler.Problems.Problem003;

public class Problem003 : Problem
{
    public override string Name => "Largest prime factor";

    public override ProblemResult Run()
    {
        var largestPrime = Run(600_851_475_143);
            
        return new ProblemResult(largestPrime, 6857);
    }

    public long Run(long number)
    {
        return Numbers.FindLargestPrimeFactor(number);
    }
}