using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler003;

[Name("Largest prime factor")]
public class Euler003 : EulerPuzzle
{
    protected override PuzzleResult Run() => 
        new(Run(600_851_475_143), "bc05f2cc254574e3679f0a25c811dea1");

    public long Run(long number) => 
        Numbers.LargestPrimeFactor(number);
}