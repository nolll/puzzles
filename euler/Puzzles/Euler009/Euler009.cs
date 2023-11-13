using Puzzles.common.Puzzles;

namespace Puzzles.euler.Puzzles.Euler009;

public class Euler009 : EulerPuzzle
{
    public override string Name => "Special Pythagorean triplet";

    protected override PuzzleResult Run()
    {
        var product = Run(1000);
        return new PuzzleResult(product, "e24ed4780cdb9cc23ed514f804dc2c80");
    }

    public int Run(int targetSum)
    {
        var combinations = GetPermutations(targetSum);

        foreach (var (a, b, c) in combinations)
        {
            if (a + b + c == targetSum && a * a + b * b == c * c)
            {
                return a * b * c;
            }
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