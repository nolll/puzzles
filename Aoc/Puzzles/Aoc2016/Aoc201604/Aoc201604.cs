using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

[Name("Security Through Obscurity")]
public class Aoc201604 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var validator = new RoomValidator(input);
        var sum = validator.SumOfIds;
        return new PuzzleResult(sum, "3b14ab13eff601ab04f28f18a3f59bda");
    }

    public PuzzleResult RunPart2(string input)
    {
        var validator = new RoomValidator(input);
        return new PuzzleResult(validator.NorthpoleObjectStorageId, "f53ac47ed914c513f86ae488f0f3c61c");
    }
}