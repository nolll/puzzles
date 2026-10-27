using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles;

[Name("Large sum")]
public class Euler013 : EulerPuzzle
{
    [Puzzle("9a8a979a38f81877c39016dde66dda45")]
    public string Solve(string input) => GetSum(input).ToString()[..10];

    private static BigInteger GetSum(string input) => input.Split(LineBreaks.Single)
        .Select(BigInteger.Parse)
        .Aggregate(new BigInteger(), (current, n) => current + n);
}