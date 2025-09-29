using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler049;

[Name("Prime Permutations")]
public class Euler049 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        const int limit = 10_000;
        var primes = Numbers.FindPrimesBelow(limit).ToArray();
        var permutationCache = primes.ToDictionary(k => k, v => string.Join("", v.ToString().ToCharArray().Order()));

        for (var i = 0; i < primes.Length; i++)
        {
            var p1 = primes[i];
            for (var j = i + 1; j < primes.Length; j++)
            {
                if (p1 == 1487)
                    continue;
                
                var p2 = primes[j];
                if (permutationCache[p1] != permutationCache[p2])
                    continue;
                
                var diff = p2 - p1;
                var p3 = p2 + diff;
                if (p3 >= limit || !Numbers.IsPrime(p3) || permutationCache[p1] != permutationCache[p3])
                    continue;
                
                var result = $"{p1}{p2}{p3}";
                return new PuzzleResult(result, "bcc1d5d8d784166b3294d174f872c8a8");
            }
        }
        
        return PuzzleResult.Failed;
    }
}