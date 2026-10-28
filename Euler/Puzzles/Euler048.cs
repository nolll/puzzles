using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles;

[Name("Self Powers")]
public class Euler048 : EulerPuzzle
{
    [Puzzle("667aee07963751238f094fa9d2b5487f")]
    public string Solve() => Enumerable.Sequence(1, 1000, 1)
        .Aggregate(new BigInteger(0), (current, i) => current + BigInteger.Pow(i, i))
        .ToString()[^10..];
}