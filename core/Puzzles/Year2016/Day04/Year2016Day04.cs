using Core.Platform;

namespace Core.Puzzles.Year2016.Day04;

public class Year2016Day04 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var validator = new RoomValidator(FileInput);
        var sum = validator.SumOfIds;
        return new PuzzleResult(sum, 278_221);
    }

    public override PuzzleResult RunPart2()
    {
        var validator = new RoomValidator(FileInput);
        return new PuzzleResult(validator.NorthpoleObjectStorageId, 267);
    }
}