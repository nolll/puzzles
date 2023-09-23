using Common;
using Common.Puzzles;

namespace Euler.Problems.Problem030;

public class Problem030 : EulerPuzzle
{
    public override string Name => "Digit fifth powers";

    public override PuzzleResult Run()
    {
        var result = Run(5);

        return new PuzzleResult(result, 443839);
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
            var sumOfPowers = digits.Select(o => Mathz.Pow(o, power)).Sum();
            if (sumOfPowers == i)
                yield return i;
        }
    }

    private static int GetUpperBound(int power)
    {
        var n = Mathz.Pow(9, power);
        var s = n.ToString();
        var l = s.Length + 1;
        return Mathz.Pow(10, l);
    }
}