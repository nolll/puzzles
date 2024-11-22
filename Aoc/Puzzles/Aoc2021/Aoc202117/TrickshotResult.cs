namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202117;

public class TrickshotResult
{
    public int MaxHeight { get; }
    public int HitCount { get; }

    public TrickshotResult(int maxHeight, int hitCount)
    {
        MaxHeight = maxHeight;
        HitCount = hitCount;
    }
}