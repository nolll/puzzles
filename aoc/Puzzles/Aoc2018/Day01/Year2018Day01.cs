using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Day01;

public class Year2018Day01 : AocPuzzle
{
    public override string Name => "Chronal Calibration";

    protected override PuzzleResult RunPart1()
    {
        var frequencyPuzzle = new FrequencyPuzzle(InputFile);
        var resultingFrequency = frequencyPuzzle.ResultingFrequency;
        return new PuzzleResult(resultingFrequency, 525);
    }

    protected override PuzzleResult RunPart2()
    {
        var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(InputFile);
        var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
        return new PuzzleResult(firstRepeatedFrequency, 75_749);
    }
}