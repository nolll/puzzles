using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201907;

public class Year2019Day07 : AocPuzzle
{
    public override string Name => "Amplification Circuit";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new ThrustCalculator(InputFile);
        var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
        return new PuzzleResult(maxThrust1, 255_590);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new ThrustCalculator(InputFile);
        var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
        return new PuzzleResult(maxThrust2, 58_285_150);
    }
}