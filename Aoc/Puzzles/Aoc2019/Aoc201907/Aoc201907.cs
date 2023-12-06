using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201907;

public class Aoc201907 : AocPuzzle
{
    public override string Name => "Amplification Circuit";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new ThrustCalculator(InputFile);
        var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
        return new PuzzleResult(maxThrust1, "2fbd6d244a35bf75a6d51c8962133afe");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new ThrustCalculator(InputFile);
        var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
        return new PuzzleResult(maxThrust2, "af273de2fc8e4b54d4d877645ded2d03");
    }
}