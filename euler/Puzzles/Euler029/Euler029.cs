using System.Numerics;
using Common.Puzzles;

namespace Euler.Puzzles.Euler029;

public class Euler029 : EulerPuzzle
{
    public override string Name => "Distinct powers";

    protected override PuzzleResult Run()
    {
        var result = Run(100);

        return new PuzzleResult(result, 9183);
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