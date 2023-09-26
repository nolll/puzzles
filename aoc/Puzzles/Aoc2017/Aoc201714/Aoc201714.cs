using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201714;

public class Aoc201714 : AocPuzzle
{
    public override string Name => "Disk Defragmentation";

    protected override PuzzleResult RunPart1()
    {
        var defragmenter = new DiskDefragmenter(Input);
        return new PuzzleResult(defragmenter.UsedCount, 8222);
    }

    protected override PuzzleResult RunPart2()
    {
        var defragmenter = new DiskDefragmenter(Input);
        return new PuzzleResult(defragmenter.RegionCount, 1086);
    }

    private const string Input = "amgozmfv";
}