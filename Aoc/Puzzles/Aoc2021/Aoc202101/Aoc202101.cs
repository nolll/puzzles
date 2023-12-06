using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202101;

public class Aoc202101 : AocPuzzle
{
    public override string Name => "Sonar Sweep";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(InputFile, false);
            
        return new PuzzleResult(result, "ff696c9ddfc6c58065e2e08cdc35e82d");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(InputFile, true);

        return new PuzzleResult(result, "5c9945a8d579421d86e2b7811105be5e");
    }
}