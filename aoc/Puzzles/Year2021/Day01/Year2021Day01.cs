using Common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day01;

public class Year2021Day01 : AocPuzzle
{
    public override string Name => "Sonar Sweep";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, false);
            
        return new PuzzleResult(result, 1477);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, true);

        return new PuzzleResult(result, 1523);
    }
}