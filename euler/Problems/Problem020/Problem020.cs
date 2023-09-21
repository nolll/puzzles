using System.Numerics;
using Euler.Platform;

namespace Euler.Problems.Problem020;

public class Problem020 : Problem
{
    public override string Name => "Factorial digit sum";

    public override ProblemResult Run()
    {
        BigInteger factorial = 100;
        var result = Run(factorial);
        return new ProblemResult(result, 648);
    }

    public int Run(BigInteger factorial)
    {
        BigInteger product = 1;
        var current = factorial;
        while (current > 0)
        {
            product *= current;
            current--;
        }

        var numbers = product.ToString().ToCharArray().Select(o => o.ToString()).Select(int.Parse);
        return numbers.Sum();
    }
}