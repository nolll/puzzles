using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201604;

[Name("Security Through Obscurity")]
public class Aoc201604 : AocPuzzle
{
    [Puzzle("3b14ab13eff601ab04f28f18a3f59bda")]
    public int Part1(string input) => new RoomValidator(input).SumOfIds;

    [Puzzle("f53ac47ed914c513f86ae488f0f3c61c")]
    public int Part2(string input) => new RoomValidator(input).NorthpoleObjectStorageId;
}