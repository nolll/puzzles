using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler009;

[Name("Special Pythagorean triplet")]
public class Euler009 : EulerPuzzle
{
    [Puzzle("e24ed4780cdb9cc23ed514f804dc2c80")]
    public int Solve() => Solve(1000);

    public int Solve(int targetSum)
    {
        foreach (var (a, b, c) in GetPermutations(targetSum))
        {
            if (a + b + c == targetSum && a * a + b * b == c * c)
                return a * b * c;
        }

        return 0;
    }

    private static IEnumerable<(int a, int b, int c)> GetPermutations(int max)
    {
        for (var a = 1; a <= max; a++)
        {
            for (var b = a + 1; b <= max; b++)
            {
                for (var c = b + 1; c <= max; c++)
                {
                    if (a + b + c == max)
                        yield return (a, b, c);
                }
            }
        }
    }
}