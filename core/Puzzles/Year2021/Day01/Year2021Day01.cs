using Core.Platform;

namespace Core.Puzzles.Year2021.Day01;

public class Year2021Day01 : Puzzle
{
    public override string Title => "Sonar Sweep";

    public override PuzzleResult RunPart1()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, false);
            
        return new PuzzleResult(result, 1477);
    }

    public override PuzzleResult RunPart2()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(FileInput, true);

        return new PuzzleResult(result, 1523);
    }
}