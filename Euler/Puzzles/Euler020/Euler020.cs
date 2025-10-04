using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler020;

[Name("Factorial digit sum")]
public class Euler020 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        BigInteger factorial = 100;
        var result = Run(factorial);
        return new PuzzleResult(result, "2969a39d498750bb2264ddfc350ab37b");
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

        return product.ToString().ToCharArray().Select(o => o.ToString()).Select(int.Parse).Sum();
    }
}