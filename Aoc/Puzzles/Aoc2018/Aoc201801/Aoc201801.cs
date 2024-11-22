using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

[Name("Chronal Calibration")]
public class Aoc201801(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var frequencyPuzzle = new FrequencyPuzzle(input);
        var resultingFrequency = frequencyPuzzle.ResultingFrequency;
        return new PuzzleResult(resultingFrequency, "6161dde7fc767cd20548aa2a500b6af4");
    }

    protected override PuzzleResult RunPart2()
    {
        var frequencyRepeatPuzzle = new FrequencyRepeatPuzzle(input);
        var firstRepeatedFrequency = frequencyRepeatPuzzle.FirstRepeatedFrequency;
        return new PuzzleResult(firstRepeatedFrequency, "fba794668dca2e1a271d8ead203f36d2");
    }
}