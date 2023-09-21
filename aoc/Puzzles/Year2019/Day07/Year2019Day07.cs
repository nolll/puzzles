using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day07;

public class Year2019Day07 : AocPuzzle
{
    public override string Name => "Amplification Circuit";

    public override PuzzleResult RunPart1()
    {
        var calculator = new ThrustCalculator(FileInput);
        var maxThrust1 = calculator.GetMaxThrust(new[] { 0, 1, 2, 3, 4 });
        return new PuzzleResult(maxThrust1, 255_590);
    }

    public override PuzzleResult RunPart2()
    {
        var calculator = new ThrustCalculator(FileInput);
        var maxThrust2 = calculator.GetMaxThrust(new[] { 5, 6, 7, 8, 9 });
        return new PuzzleResult(maxThrust2, 58_285_150);
    }
}