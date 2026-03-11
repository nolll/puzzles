using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler013;

[Name("Large sum")]
public class Euler013 : EulerPuzzle
{
    [Puzzle("9a8a979a38f81877c39016dde66dda45")]
    public string Solve(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var numbers = rows.Select(BigInteger.Parse);
        
        var sum = numbers.Aggregate(new BigInteger(), (current, n) => current + n);
        return sum.ToString()[..10];
    }
}