using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler010;

[Name("Summation of primes")]
public class Euler010 : EulerPuzzle
{
    [Puzzle("91e6ee4eecd36e3d7d1278ed37721706")]
    public long Solve() => Solve(2_000_000);

    public long Solve(int limit) => 
        Numbers.FindPrimesBelow(limit).Aggregate<int, long>(0, (current, p) => current + p);
}