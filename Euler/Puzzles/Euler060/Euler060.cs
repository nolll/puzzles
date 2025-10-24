using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler060;

[Name("Prime Pair Sets")]
[IsSlow, Comment("Better prime cache?")]
public class Euler060 : EulerPuzzle
{
    private readonly Dictionary<int, bool> _primeCache = new();
    private readonly Dictionary<int[], bool> _cache = new();
    private const int Depth = 5;
    private const int RecursiveDepth = Depth - 1;
    
    public PuzzleResult Run()
    {
        const int upperbound = 8500; // Found answer with 10000, then decreased. Still too slow
        var primes = Numbers.FindPrimesBelow(upperbound).ToArray();

        var results = RunRecursive(primes, 0, []);
        var best = results.Min();
        
        return new PuzzleResult(best, "3889e098b841c125e0922c73ad776234");
    }

    private List<int> RunRecursive(int[] primes, int startPos, int[] set)
    {
        var list = new List<int>();
        var length = set.Length;
        for (var i = startPos; i < primes.Length; i++)
        {
            int[] newset = [..set, primes[i]];
            var isValid = IsValid(newset);
            if (!isValid)
                continue;
            
            if(length == RecursiveDepth)
                list.Add(newset.Sum());
            else
                list.AddRange(RunRecursive(primes, i + 1, newset));
        }

        return list;
    }

    private bool IsValid(int[] values)
    {
        var isValid = PermutationGenerator.GetPermutations(values, 2)
            .All(o => IsPairPrime(o.ToArray()));

        _cache.Add(values, isValid);
        return isValid;
    }
    
    private bool IsPairPrime(int[] values)
    {
        if (_cache.TryGetValue(values, out var isValid))
            return isValid;
        
        isValid = IsPrime(Numbers.Concat(values));
        _cache.Add(values, isValid);
        return isValid;
    }

    private bool IsPrime(int n)
    {
        if (_primeCache.TryGetValue(n, out var isPrime))
            return isPrime;
        
        isPrime = Numbers.IsPrime(n);
        _primeCache.Add(n, isPrime);
        return isPrime;
    }
}