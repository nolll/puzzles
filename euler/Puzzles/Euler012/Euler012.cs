using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler012;

public class Euler012 : EulerPuzzle
{
    public override string Name => "Highly divisible triangular number";

    protected override PuzzleResult Run()
    {
        var result = Run(501);
        return new PuzzleResult(result, "8091de7d285989bbfa9a2f9f3bdcc7c0");
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