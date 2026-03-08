using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201714;

[Name("Disk Defragmentation")]
public class Aoc201714 : AocPuzzle
{
    [Puzzle("b6c685ad1667d629c3f6a13cc52ee2d0")]
    public int Part1(string input) => new DiskDefragmenter(input).UsedCount;

    [Puzzle("3e2bb366df3fce1977350353f38f3787")]
    public int Part2(string input) => new DiskDefragmenter(input).RegionCount;
}