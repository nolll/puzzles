using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler053;

[Name("Combinatoric Selections")]
public class Euler053 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var count = 0;
        
        for (var i = 1; i <= 100; i++)
        {
            var n = new BigInteger(i);

            for (var j = 0; j <= i - 1; j++)
            {
                var r = new BigInteger(j);
                
                var permutations = Numbers.Factorial(n) / (Numbers.Factorial(r) * Numbers.Factorial(n - r));
                if (permutations > 1_000_000)
                    count++;
            }
        }
        
        return new PuzzleResult(count, "afc3b71561c7dde3bc566dc3985992bf");
    }
}