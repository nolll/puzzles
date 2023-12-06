namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202117;

public class TrickshotTarget
{
    public int XMin { get; }
    public int XMax { get; }
    public int YMin { get; }
    public int YMax { get; }

    public int VxMin { get; }
    public int VxMax { get; }
    public int VyMin { get; }
    public int VyMax { get; }

    public TrickshotTarget(int xMin, int xMax, int yMin, int yMax)
    {
        XMin = xMin;
        XMax = xMax;
        YMin = yMin;
        YMax = yMax;
            
        VxMax = Math.Max(Math.Abs(xMin), Math.Abs(xMax));
        VxMin = -VxMax;

        VyMax = Math.Max(Math.Abs(yMin), Math.Abs(yMax));
        VyMin = -VyMax;
    }
}