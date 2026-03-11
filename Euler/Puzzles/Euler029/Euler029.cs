using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler029;

[Name("Distinct powers")]
public class Euler029 : EulerPuzzle
{
    [Puzzle("b83681bf81eb63901be2e8b5b1569c45")]
    public int Solve() => Solve(100);

    public int Solve(int limit)
    {
        var cache = new HashSet<BigInteger>();

        for (var a = 2; a <= limit; a++)
        {
            for (var b = 2; b <= limit; b++)
            {
                cache.Add(BigInteger.Pow(a, b));
            }
        }

        return cache.Count;
    }
}