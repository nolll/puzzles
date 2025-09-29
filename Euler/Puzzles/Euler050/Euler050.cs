using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler050;

[Name("Consecutive Prime Sum")]
public class Euler050 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        const int limit = 1_000_000;
        var primes = Numbers.FindPrimesBelow(limit).ToArray();
        var best = (count: 0, sum: 0);

        for (var i = 0; i < primes.Length; i++)
        {
            var sum = primes[i];
            var termCount = 0;
            for (var j = i + 1; j < primes.Length; j++)
            {
                sum += primes[j];
                termCount++;
                
                if (sum > limit)
                    break;

                if (Numbers.IsPrime(sum) && termCount > best.count) 
                    best = (termCount, sum);
            }
        }
        
        return new PuzzleResult(best.sum, "637f443473ae731a5a53aebf19543597");
    }
}