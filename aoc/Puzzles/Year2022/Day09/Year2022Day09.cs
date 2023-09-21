using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day09;

public class Year2022Day09 : AocPuzzle
{
    public override string Name => "Rope Bridge";

    public override PuzzleResult RunPart1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(FileInput);

        return new PuzzleResult(result, 6284);
    }

    public override PuzzleResult RunPart2()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(FileInput);

        return new PuzzleResult(result, 2661);
    }
}