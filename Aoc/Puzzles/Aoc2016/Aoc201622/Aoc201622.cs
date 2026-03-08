using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201622;

[Name("Grid Computing")]
public class Aoc201622 : AocPuzzle
{
    [Puzzle("75405bd6fc453111e999ebdc18ba4f78")]
    public int Part1(string input) => new StorageGrid(input).GetViablePairCount();

    [Puzzle("112a5875109cbca20cbe3dd1d02fe9fd")]
    public int Part2(string input) => new StorageGrid(input).MoveStorage();
}