using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Debug;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler051;

[Name("Prime Digit Replacements")]
public class Euler051 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var n = 0;
        const int target = 8;

        while (true)
        {
            n++;

            if (n % 2 == 0 || !Numbers.IsPrime(n)) 
                continue;
            
            var chars = n.ToString().ToCharArray();
            var slots = Enumerable.Range(0, chars.Length).ToList();

            for (var replacementCount = 1; replacementCount < chars.Length; replacementCount++)
            {
                var permutations = CombinationGenerator.GetUniqueCombinationsFixedSize(slots, replacementCount);
                foreach (var positionsToReplace in permutations)
                {
                    var primes = new HashSet<int>();
                    var current = chars.ToList();
                    for (var c = '0'; c <= '9'; c++)
                    {
                        if (positionsToReplace.Contains(0) && c == '0')
                            continue;
                            
                        foreach (var positionToReplace in positionsToReplace)
                        {
                            current[positionToReplace] = c;
                        }
                            
                        var currentNum = int.Parse(string.Join("", current));
                            
                        if (Numbers.IsPrime(currentNum)) 
                            primes.Add(currentNum);
                    }
                            
                    if (primes.Count == target)
                        return new PuzzleResult(primes.Min(), "359af98eb6058f7574c6d66b403910c5");
                }
            }
        }
    }
}