using Common.Combinatorics;
using Common.Numbers;
using Common.Puzzles;

namespace Euler.Puzzles.Euler041;

public class Euler041 : EulerPuzzle
{
    public override string Name => "Pandigital Prime";

    protected override PuzzleResult Run()
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
        
        return new PuzzleResult(largest, "d0a1bd6ab4229b2d0754be8923431404");
    }
}