namespace App.Puzzles.Year2021.Day17;

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