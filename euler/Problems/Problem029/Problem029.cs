using System.Numerics;
using Euler.Platform;

namespace Euler.Problems.Problem029;

public class Problem029 : EulerPuzzle
{
    public override string Name => "Distinct powers";

    public override ProblemResult Run()
    {
        var result = Run(100);

        return new ProblemResult(result, 9183);
    }

    public int Run(int limit)
    {
        var cache = new HashSet<BigInteger>();

        for (var a = 2; a <= limit; a++)
        {
            for (var b = 2; b <= limit; b++)
            {
                var result = BigInteger.Pow(a, b);
                if (!cache.Contains(result))
                    cache.Add(result);
            }
        }

        return cache.Count;
    }
}