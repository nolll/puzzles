using Pzl.Common;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler030;

[Name("Digit fifth powers")]
public class Euler030 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var result = Run(5);

        return new PuzzleResult(result, "7ba4d46ba8ab138fff39c45c1e2b574b");
    }

    public int Run(int power)
    {
        var upperBound = GetUpperBound(power);
        var results = GetNumbers(power, upperBound);
            
        return results.Sum();
    }

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

    private static int GetUpperBound(int power)
    {
        var n = MathTools.Pow(9, power);
        var s = n.ToString();
        var l = s.Length + 1;
        return MathTools.Pow(10, l);
    }
}