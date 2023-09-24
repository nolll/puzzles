using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202101;

public class Year2021Day01 : AocPuzzle
{
    public override string Name => "Sonar Sweep";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(InputFile, false);
            
        return new PuzzleResult(result, 1477);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(InputFile, true);

        return new PuzzleResult(result, 1523);
    }
}