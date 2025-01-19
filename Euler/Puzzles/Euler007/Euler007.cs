using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler007;

[Name("10001st prime")]
public class Euler007 : EulerPuzzle
{
    public PuzzleResult Run(string input)
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