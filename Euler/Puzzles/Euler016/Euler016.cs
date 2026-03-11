using Pzl.Common;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler016;

[Name("Power digit sum")]
public class Euler016 : EulerPuzzle
{
    [Puzzle("09386463dd33adc5ea634c4084b68919")]
    public int Solve() => Solve(1000);

    public int Solve(int power) => MathTools.ToPowerOf(2, power).ToString()
        .ToCharArray()
        .Select(o => int.Parse(o.ToString()))
        .Sum();
}