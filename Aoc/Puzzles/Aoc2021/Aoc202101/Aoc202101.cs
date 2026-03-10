using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202101;

[Name("Sonar Sweep")]
public class Aoc202101 : AocPuzzle
{
    [Puzzle("ff696c9ddfc6c58065e2e08cdc35e82d")]
    public PuzzleResult Part1(string input)
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(input, false);
            
        return new PuzzleResult(result);
    }

    [Puzzle("5c9945a8d579421d86e2b7811105be5e")]
    public PuzzleResult Part2(string input)
    {
        var calculator = new DepthMeasurement();
        var result = calculator.GetNumberOfIncreasingMeasurements(input, true);

        return new PuzzleResult(result);
    }
}