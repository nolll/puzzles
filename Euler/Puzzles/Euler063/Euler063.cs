using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler063;

[Name("Powerful Digit Counts")]
public class Euler063 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var results = new HashSet<BigInteger>();
        var n = 1;
        while (n < 10)
        {
            for (var exp = 1; exp < 25; exp++)
            {
                var r = BigInteger.Pow(n, exp);
                var digitCount = r.ToString().Length;
                if (digitCount == exp) 
                    results.Add(r);
            }
            n++;
        }
        
        return new PuzzleResult(results.Count, "f8456799fb007870bc7065fe8d61b770");
    }

}