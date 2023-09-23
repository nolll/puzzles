using Common.Maths;
using Common.Puzzles;

namespace Euler.Puzzles.Euler016;

public class Euler016 : EulerPuzzle
{
    public override string Name => "Power digit sum";

    protected override PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, 1366);
    }

    public int Run(int power)
    {
        var product = MathTools.ToPowerOf(2, power);
        return product.ToString()
            .ToCharArray()
            .Select(o => o.ToString())
            .Select(int.Parse)
            .Sum();
    }
}