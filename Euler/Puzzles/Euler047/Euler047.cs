using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler047;

[Name("Distinct Primes Factors")]
public class Euler047 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var n = 1;
        const int searchFor = 4;
        var correctCount = 0;

        while (correctCount != searchFor)
        {
            correctCount = MathTools.GetFactors(n).Count(Numbers.IsPrime) == searchFor
                ? correctCount + 1
                : 0;

            n++;
        }

        var firstInSeries = n - searchFor;
        
        return new PuzzleResult(firstInSeries, "eac3c019f679164d514795ae37eaa2c7");
    }
}