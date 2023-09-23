using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day04;

public class Year2016Day04 : AocPuzzle
{
    public override string Name => "Security Through Obscurity";

    protected override PuzzleResult RunPart1()
    {
        var validator = new RoomValidator(FileInput);
        var sum = validator.SumOfIds;
        return new PuzzleResult(sum, 278_221);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new RoomValidator(FileInput);
        return new PuzzleResult(validator.NorthpoleObjectStorageId, 267);
    }
}