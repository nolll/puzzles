using Puzzles.common.Numbers;
using Puzzles.common.Puzzles;

namespace Puzzles.euler.Puzzles.Euler007;

public class Euler007 : EulerPuzzle
{
    public override string Name => "10001st prime";

    protected override PuzzleResult Run()
    {
        var nthPrime = Run(10001);

        return new PuzzleResult(nthPrime, "42330f784700c1eb6c8e5aab1559caa5");
    }

    public int Run(int index)
    {
        var primeCount = 0;
        var lastPrime = 0;
        var i = 2;
            
        while (primeCount < index)
        {
            if (Numbers.IsPrime(i))
            {
                lastPrime = i;
                primeCount++;
            }

            i++;
        }
            
        return lastPrime;
    }
}