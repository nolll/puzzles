using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Day08;

public class Year2021Day08 : AocPuzzle
{
    public override string Name => "Seven Segment Search";

    protected override PuzzleResult RunPart1()
    {
        var decoder = new SevenSegmentDisplayDecoder(InputFile);
        var result = decoder.GetEasyNumbers();
        return new PuzzleResult(result, 278);
    }

    protected override PuzzleResult RunPart2()
    {
        var decoder = new SevenSegmentDisplayDecoder(InputFile);
        var result = decoder.GetDecodedSum();
        return new PuzzleResult(result, 986179);
    }
}