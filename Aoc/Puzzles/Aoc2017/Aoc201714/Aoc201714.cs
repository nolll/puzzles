using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201714;

[Name("Disk Defragmentation")]
public class Aoc201714 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var defragmenter = new DiskDefragmenter(input);
        return new PuzzleResult(defragmenter.UsedCount, "b6c685ad1667d629c3f6a13cc52ee2d0");
    }

    public PuzzleResult RunPart2(string input)
    {
        var defragmenter = new DiskDefragmenter(input);
        return new PuzzleResult(defragmenter.RegionCount, "3e2bb366df3fce1977350353f38f3787");
    }
}