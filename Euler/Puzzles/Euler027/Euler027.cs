using Puzzles.Common.Numbers;
using Puzzles.Common.Puzzles;

namespace Pzl.Euler.Puzzles.Euler027;

public class Euler027 : EulerPuzzle
{
    public override string Name => "Quadratic primes";
    private readonly Dictionary<int, bool> _primeCache;

    public Euler027()
    {
        _primeCache = new Dictionary<int, bool>();
    }

    protected override PuzzleResult Run()
    {
        const int limit = 1000;
        const int aLimit = limit - 1;
        const int bLimit = limit;
        const int aMin = -aLimit;
        const int aMax = aLimit;
        const int bMin = -bLimit;
        const int bMax = bLimit;
        var mostPrimes = 0;
        var product = 0;

        for (var a = aMin; a <= aMax; a++)
        {
            for (var b = bMin; b <= bMax; b++)
            {
                var primeCount = GetPrimeCount(a, b);
                if (primeCount > mostPrimes)
                {
                    mostPrimes = primeCount;
                    product = a * b;
                }
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