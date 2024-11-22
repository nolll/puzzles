namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201823;

public class Nanobot
{
    public Point3d Coords { get; }
    public int SignalRadius { get; }

    public Nanobot(Point3d coords, int signalRadius)
    {
        Coords = coords;
        SignalRadius = signalRadius;
    }

    public bool IsInRange(Nanobot otherBot)
    {
        var distance = ManhattanDistanceTo(otherBot);
        return distance <= SignalRadius;
    }

    public bool IsInRange(int x, int y, int z)
    {
        var distance = ManhattanDistanceTo(x, y, z);
        return distance <= SignalRadius;
    }

    private int ManhattanDistanceTo(Nanobot other)
    {
        return Coords.ManhattanDistanceTo(other.Coords);
    }

    private int ManhattanDistanceTo(int x, int y, int z)
    {
        return Coords.ManhattanDistanceTo(x, y, z);
    }
}