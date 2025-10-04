using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler041;

[Name("Pandigital Prime")]
public class Euler041 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var largest = 0L;
        for (var x = 9; x >= 1; x--)
        {
            var numbers = Enumerable.Range(1, x).ToList();
            var combinations = PermutationGenerator.GetPermutations(numbers);

            foreach (var combination in combinations)
            {
                var n = long.Parse(string.Join("", combination));
                if (n > largest && Numbers.IsPrime(n))
                    largest = n;
            }

            if (largest > 0)
                break;
        }
        
        return new PuzzleResult(largest, "6aecd31e595c9172b15112c8ef913306");
    }
}