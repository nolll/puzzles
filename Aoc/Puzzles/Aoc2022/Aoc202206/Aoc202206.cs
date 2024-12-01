using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202206;

[Name("Tuning Trouble")]
public class Aoc202206 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = TuningTrouble.FindMarker(input);
        return new PuzzleResult(result, "df3123551cc80e1f0ce2d1ce2c900f7d");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = TuningTrouble.FindMessage(input);
        return new PuzzleResult(result, "7b7d3c62d59d828eb3c5f0b8985d39e8");
    }
}