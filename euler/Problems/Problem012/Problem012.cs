using common.Numbers;
using Euler.Platform;

namespace Euler.Problems.Problem012;

public class Problem012 : Problem
{
    public override string Name => "Highly divisible triangular number";
        
    public override ProblemResult Run()
    {
        var result = Run(501);
        return new ProblemResult(result, 76576500);
    }

    public int Run(int maxFactorCount)
    {
        var current = 1;
        var triangle = current;

        while (true)
        {
            var factorCount = Numbers.GetAllDivisors(triangle).Count();

            if (factorCount > maxFactorCount)
                return triangle;

            current++;
            triangle += current;
        }
    }
}