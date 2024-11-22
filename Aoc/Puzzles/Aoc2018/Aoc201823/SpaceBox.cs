namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

public class SpaceBox
{
    public Point3d Min { get; }
    public Point3d Max { get; }

    public int SizeX => Max.X - Min.X + 1;
    public int SizeY => Max.Y - Min.Y + 1;
    public int SizeZ => Max.Z - Min.Z + 1;
    public long Size => (long)SizeX * SizeY * SizeZ;

    public SpaceBox(Point3d min, Point3d max)
    {
        Min = min;
        Max = max;
    }

    public IEnumerable<SpaceBox> Divide()
    {
        var xMid = Min.X + SizeX / 2;
        var yMid = Min.Y + SizeY / 2;
        var zMid = Min.Z + SizeZ / 2;

        var splitX = SizeX > 1;
        var splitY = SizeY > 1;
        var splitZ = SizeZ > 1;

        var x1Min = Min.X;
        var x1Max = splitX ? xMid - 1 : xMid;
        var x2Min = xMid;
        var x2Max = Max.X;

        var y1Min = Min.Y;
        var y1Max = splitY ? yMid - 1 : yMid;
        var y2Min = yMid;
        var y2Max = Max.Y;

        var z1Min = Min.Z;
        var z1Max = splitZ ? zMid - 1 : zMid;
        var z2Min = zMid;
        var z2Max = Max.Z;

        yield return new SpaceBox(new Point3d(x1Min, y1Min, z1Min), new Point3d(x1Max, y1Max, z1Max));

        if (splitX)
            yield return new SpaceBox(new Point3d(x2Min, y1Min, z1Min), new Point3d(x2Max, y1Max, z1Max));

        if (splitY)
            yield return new SpaceBox(new Point3d(x1Min, y2Min, z1Min), new Point3d(x1Max, y2Max, z1Max));

        if (splitZ)
            yield return new SpaceBox(new Point3d(x1Min, y1Min, z2Min), new Point3d(x1Max, y1Max, z2Max));

        if (splitX && splitY)
            yield return new SpaceBox(new Point3d(x2Min, y2Min, z1Min), new Point3d(x2Max, y2Max, z1Max));

        if (splitX && splitZ)
            yield return new SpaceBox(new Point3d(x2Min, y1Min, z2Min), new Point3d(x2Max, y1Max, z2Max));

        if (splitY && splitZ)
            yield return new SpaceBox(new Point3d(x1Min, y2Min, z2Min), new Point3d(x1Max, y2Max, z2Max));

        if (splitX && splitY && splitZ)
            yield return new SpaceBox(new Point3d(x2Min, y2Min, z2Min), new Point3d(x2Max, y2Max, z2Max));
    }
}