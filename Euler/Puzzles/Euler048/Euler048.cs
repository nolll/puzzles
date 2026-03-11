using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler048;

[Name("Self Powers")]
public class Euler048 : EulerPuzzle
{
    [Puzzle("667aee07963751238f094fa9d2b5487f")]
    public string Solve()
    {
        var sum = new BigInteger(0);
        
        for (var i = 1; i <= 1000; i++)
        {
            sum += BigInteger.Pow(i, i);
        }

        return sum.ToString()[^10..];
    }
}