using System.Numerics;
using Common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem020;

public class Problem020 : EulerPuzzle
{
    public override string Name => "Factorial digit sum";

    public override PuzzleResult Run()
    {
        BigInteger factorial = 100;
        var result = Run(factorial);
        return new PuzzleResult(result, 648);
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