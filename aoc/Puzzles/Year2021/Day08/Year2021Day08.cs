using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day08;

public class Year2021Day08 : AocPuzzle
{
    public override string Title => "Seven Segment Search";

    public override PuzzleResult RunPart1()
    {
        var decoder = new SevenSegmentDisplayDecoder(FileInput);
        var result = decoder.GetEasyNumbers();
        return new PuzzleResult(result, 278);
    }

    public override PuzzleResult RunPart2()
    {
        var decoder = new SevenSegmentDisplayDecoder(FileInput);
        var result = decoder.GetDecodedSum();
        return new PuzzleResult(result, 986179);
    }
}