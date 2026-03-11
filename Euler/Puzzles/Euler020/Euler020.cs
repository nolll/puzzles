using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler020;

[Name("Factorial digit sum")]
public class Euler020 : EulerPuzzle
{
    [Puzzle("2969a39d498750bb2264ddfc350ab37b")]
    public int Solve() => Solve(100);

    public int Solve(int factorial) => Enumerable.Range(1, factorial).Aggregate<int, BigInteger>(1, (current, i) => current * i)
        .ToString()
        .Select(o => int.Parse(o.ToString()))
        .Sum();
}