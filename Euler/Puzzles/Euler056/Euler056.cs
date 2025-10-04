using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler056;

[Name("Powerful Digit Sum")]
public class Euler056 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        const int limit = 100;
        var best = 0;
        
        for (var n = 0; n < limit; n++)
        {
            for (var exp = 0; exp < limit; exp++)
            {
                var sum = BigInteger.Pow(new BigInteger(n), exp).ToString().Select(o => int.Parse(o.ToString())).Sum();
                best = Math.Max(best, sum);
            }
        }
        
        return new PuzzleResult(best, "376414390a4252665a1c96ce1464a605");
    }
}