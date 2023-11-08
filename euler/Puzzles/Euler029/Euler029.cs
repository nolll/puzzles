using System.Numerics;
using Common.Puzzles;

namespace Euler.Puzzles.Euler029;

public class Euler029 : EulerPuzzle
{
    public override string Name => "Distinct powers";

    protected override PuzzleResult Run()
    {
        var result = Run(100);

        return new PuzzleResult(result, "6f0ca67289d79eb35d19decbc0a08453");
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