using Core.Platform;

namespace Core.Puzzles.Year2022.Day15;

public class Year2022Day15 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var zone = new BeaconZone();
        var result = zone.Part1(FileInput, 2_000_000, false);

        // guess 4580782, too low
        // guess 4055737, too low

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}