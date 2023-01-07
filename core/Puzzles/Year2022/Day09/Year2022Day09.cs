using Core.Platform;

namespace Core.Puzzles.Year2022.Day09;

public class Year2022Day09 : Puzzle
{
    public override string Title => "Rope Bridge";

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