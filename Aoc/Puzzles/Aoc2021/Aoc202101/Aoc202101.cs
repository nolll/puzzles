using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202101;

[Name("Sonar Sweep")]
public class Aoc202101 : AocPuzzle
{
    [Puzzle("ff696c9ddfc6c58065e2e08cdc35e82d")]
    public int Part1(string input) => new DepthMeasurement().GetNumberOfIncreasingMeasurements(input, false);

    [Puzzle("5c9945a8d579421d86e2b7811105be5e")]
    public int Part2(string input) => new DepthMeasurement().GetNumberOfIncreasingMeasurements(input, true);
}