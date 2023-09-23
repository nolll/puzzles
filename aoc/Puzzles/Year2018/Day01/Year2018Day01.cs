using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day01;

public class Year2018Day01 : AocPuzzle
{
    public override string Name => "Chronal Calibration";

    protected override PuzzleResult RunPart1()
    {
        var frequencyPuzzle = new FrequencyPuzzle(FileInput);
        var resultingFrequency = frequencyPuzzle.ResultingFrequency;
        return new PuzzleResult(resultingFrequency, 525);
    }

    protected override PuzzleResult RunPart2()
    {
        var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(FileInput);
        var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
        return new PuzzleResult(firstRepeatedFrequency, 75_749);
    }
}