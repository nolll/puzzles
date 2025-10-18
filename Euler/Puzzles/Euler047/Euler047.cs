using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler047;

[Name("Distinct Primes Factors")]
public class Euler047 : EulerPuzzle
{
    public PuzzleResult Run() => new(FindSeries(4), "eac3c019f679164d514795ae37eaa2c7");

    public int FindSeries(int searchFor)
    {
        var n = 1;
        var correctCount = 0;
        
        // This is an optimization. Solved without precalc in about 20s
        var primes = Numbers.FindPrimesBelow(700).ToArray();

        while (correctCount != searchFor)
        {
            correctCount = MathTools.GetFactors(primes, n).Count(Numbers.IsPrime) == searchFor
                ? correctCount + 1
                : 0;

            n++;
        }

        return n - searchFor;
    }
}