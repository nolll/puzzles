using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

[Name("Chronal Calibration")]
public class Aoc201801 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var frequencyPuzzle = new FrequencyPuzzle(input);
        var resultingFrequency = frequencyPuzzle.ResultingFrequency;
        return new PuzzleResult(resultingFrequency, "6161dde7fc767cd20548aa2a500b6af4");
    }

    public PuzzleResult RunPart2(string input)
    {
        var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(input);
        var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
        return new PuzzleResult(firstRepeatedFrequency, "fba794668dca2e1a271d8ead203f36d2");
    }
}