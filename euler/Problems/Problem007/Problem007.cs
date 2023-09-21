using common.Numbers;
using Euler.Platform;

namespace Euler.Problems.Problem007;

public class Problem007 : Problem
{
    public override string Name => "10001st prime";

    public override ProblemResult Run()
    {
        var nthPrime = Run(10001);

        return new ProblemResult(nthPrime, 104743);
    }

    public int Run(int index)
    {
        var primeCount = 0;
        var lastPrime = 0;
        var i = 2;
            
        while (primeCount < index)
        {
            if (Numbers.IsPrime(i))
            {
                lastPrime = i;
                primeCount++;
            }

            i++;
        }
            
        return lastPrime;
    }
}