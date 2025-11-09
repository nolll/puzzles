using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler013;

[Name("Large sum")]
public class Euler013 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var numbers = rows.Select(BigInteger.Parse);

        var sum = new BigInteger();
        sum = numbers.Aggregate(sum, (current, n) => current + n);
        var result = sum.ToString()[..10];
        return new PuzzleResult(result, "9a8a979a38f81877c39016dde66dda45");
    }
}