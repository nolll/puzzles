using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

[Name("Security Through Obscurity")]
public class Aoc201604(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var validator = new RoomValidator(Input);
        var sum = validator.SumOfIds;
        return new PuzzleResult(sum, "3b14ab13eff601ab04f28f18a3f59bda");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new RoomValidator(Input);
        return new PuzzleResult(validator.NorthpoleObjectStorageId, "f53ac47ed914c513f86ae488f0f3c61c");
    }
}