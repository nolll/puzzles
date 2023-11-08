using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler012;

public class Euler012 : EulerPuzzle
{
    public override string Name => "Highly divisible triangular number";

    protected override PuzzleResult Run()
    {
        var result = Run(501);
        return new PuzzleResult(result, "fea73831ed90d121b1b03e10004a2ead");
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