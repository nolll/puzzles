using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler027;

[Name("Quadratic primes")]
public class Euler027 : EulerPuzzle
{
    private readonly Dictionary<int, bool> _primeCache = new();

    public PuzzleResult Run()
    {
        const int bLimit = 1000;
        const int aLimit = bLimit - 1;
        const int aMin = -aLimit;
        const int bMin = -bLimit;
        var mostPrimes = 0;
        var product = 0;

        for (var a = aMin; a <= aLimit; a++)
        {
            for (var b = bMin; b <= bLimit; b++)
            {
                var primeCount = GetPrimeCount(a, b);
                if (primeCount <= mostPrimes)
                    continue;
                
                mostPrimes = primeCount;
                product = a * b;
            }
        }
            
        return new PuzzleResult(product, "f850d309dbbe391934e0e67a6344442d");
    }

    public int GetPrimeCount(int a, int b)
    {
        var n = -1;
        var isPrime = true;
            
        while (isPrime)
        {
            n++;
            var r = n * n + a * n + b;
            isPrime = IsPrime(Math.Abs(r));
        }

        return n;
    }

    private bool IsPrime(int r)
    {
        if (_primeCache.TryGetValue(r, out var isPrime))
            return isPrime;
            
        isPrime = Numbers.IsPrime(r);
        _primeCache.Add(r, isPrime);
        return isPrime;
    }
}