using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler046;

[Name("Goldbach's Other Conjecture")]
public class Euler046 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var n = 1;
        var found = true;
        
        while (found)
        {
            n += 2;
            
            if (Numbers.IsPrime(n))
                continue;

            var primes = Numbers.FindPrimesBelow(n);
            var squares = FindSquaresBelow(n / 2).ToList();

            found = false;
            foreach (var prime in primes)
            {
                foreach (var square in squares)
                {
                    if (prime + 2 * square == n)
                        found = true;
                }
            }
        }
        
        return new PuzzleResult(n, "062b9f78d646c2335a67be87369acfeb"); 
    }

    private static IEnumerable<int> FindSquaresBelow(int max)
    {
        var n = 1;
        var square = 1;
        while (square < max)
        {
            yield return square;
            n++;
            square = n * n;
        }
    }
}