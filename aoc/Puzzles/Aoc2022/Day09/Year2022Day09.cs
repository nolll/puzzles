using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Day09;

public class Year2022Day09 : AocPuzzle
{
    public override string Name => "Rope Bridge";

    protected override PuzzleResult RunPart1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(InputFile);

        return new PuzzleResult(result, 6284);
    }

    protected override PuzzleResult RunPart2()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(InputFile);

        return new PuzzleResult(result, 2661);
    }
}