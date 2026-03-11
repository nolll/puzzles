using Pzl.Common;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler030;

[Name("Digit fifth powers")]
public class Euler030 : EulerPuzzle
{
    [Puzzle("7ba4d46ba8ab138fff39c45c1e2b574b")]
    public int Solve() => Solve(5);

    public int Solve(int power) => GetNumbers(power, GetUpperBound(power)).Sum();

    private static IEnumerable<int> GetNumbers(int power, int upperBound)
    {
        for (var i = 2; i < upperBound; i++)
        {
            var digits = i.ToString().ToCharArray().Select(o => int.Parse(o.ToString()));
            var sumOfPowers = digits.Select(o => MathTools.Pow(o, power)).Sum();
            if (sumOfPowers == i)
                yield return i;
        }
    }

    private static int GetUpperBound(int power) => MathTools.Pow(10, MathTools.Pow(9, power).ToString().Length + 1);
}