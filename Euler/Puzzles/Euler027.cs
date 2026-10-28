using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles;

[Name("Quadratic primes")]
public class Euler027 : EulerPuzzle
{
    [Puzzle("f850d309dbbe391934e0e67a6344442d")]
    public int Solve()
    {
        const int bLimit = 1000;
        const int aLimit = bLimit - 1;
        const int aMin = -aLimit;
        const int bMin = -bLimit;
        var mostPrimes = 0;
        var product = 0;
        var cache = new Dictionary<int, bool>();

        for (var a = aMin; a <= aLimit; a++)
        {
            for (var b = bMin; b <= bLimit; b++)
            {
                var primeCount = GetPrimeCount(cache, a, b);
                if (primeCount <= mostPrimes)
                    continue;
                
                mostPrimes = primeCount;
                product = a * b;
            }
        }
            
        return product;
    }

    public int GetPrimeCount(Dictionary<int, bool> cache, int a, int b)
    {
        var n = -1;
        var isPrime = true;
            
        while (isPrime)
        {
            n++;
            var r = n * n + a * n + b;
            isPrime = IsPrime(cache, Math.Abs(r));
        }

        return n;
    }

    private bool IsPrime(Dictionary<int, bool> cache, int r)
    {
        if (cache.TryGetValue(r, out var isPrime))
            return isPrime;
            
        isPrime = Numbers.IsPrime(r);
        cache.Add(r, isPrime);
        return isPrime;
    }
}