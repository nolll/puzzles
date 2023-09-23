using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler007;

public class Euler007 : EulerPuzzle
{
    public override string Name => "10001st prime";

    public override PuzzleResult Run()
    {
        var nthPrime = Run(10001);

        return new PuzzleResult(nthPrime, 104743);
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