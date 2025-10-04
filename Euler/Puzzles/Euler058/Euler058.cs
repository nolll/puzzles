using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler058;

[Name("Spiral Primes")]
public class Euler058 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        const int cornerCount = 4;
        var n = 1;
        var width = 1;
        var cornerDistance = 2;
        var primesCount = 0;
        var nonPrimeCount = 1;

        while (true)
        {
            for (var i = 0; i < cornerCount; i++)
            {
                n += cornerDistance;
                if (Numbers.IsPrime(n))
                    primesCount++;
                else
                    nonPrimeCount++;
            }

            width += 2;
            cornerDistance += 2;

            if ((double)primesCount / (nonPrimeCount + primesCount) < 0.1)
                break;
        }
        
        return new PuzzleResult(width, "5f412b91d43e2c0e840ce0ef16b76436");
    }
}