using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler065;

[Name("Convergents of e")]
public class Euler065 : EulerPuzzle
{
    private const int Start = 2;
    
    [Puzzle("e58b666bd08fdb2db4284193545ca076")]
    public BigInteger Solve() => NumeratorSum(100);

    public BigInteger NumeratorSum(int levels)
    {
        var result = MathTools.ContinuedFraction(Start, GetSequence(levels - 1), levels - 1);
        return Numbers.DigitSum(result.Numerator);
    }
    
    public int[] GetSequence(int levels) => [1, ..GenerateSequence(levels - 1)];
    private IEnumerable<int> GenerateSequence(int n) => Enumerable.Range(0, n).Select(GenerateNumber);
    private static int GenerateNumber(int n) => n % 3 == 0 ? (n / 3 + 1) * 2 : 1;
}