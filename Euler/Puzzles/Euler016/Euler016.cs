using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler016;

[Name("Power digit sum")]
public class Euler016 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var result = Run(1000);
        return new PuzzleResult(result, "09386463dd33adc5ea634c4084b68919");
    }

    public int Run(int power) => MathTools.ToPowerOf(2, power).ToString()
        .ToCharArray()
        .Select(o => o.ToString())
        .Select(int.Parse)
        .Sum();
}