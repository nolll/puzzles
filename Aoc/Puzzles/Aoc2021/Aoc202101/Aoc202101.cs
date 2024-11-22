using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202101;

[Name("Sonar Sweep")]
public class Aoc202101(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(input, false);
            
        return new PuzzleResult(result, "ff696c9ddfc6c58065e2e08cdc35e82d");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(input, true);

        return new PuzzleResult(result, "5c9945a8d579421d86e2b7811105be5e");
    }
}