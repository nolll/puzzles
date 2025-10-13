using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

public enum PortalType
{
    Inner,
    Outer
}

public abstract class DonutPortal
{
    public string Name { get; }
    public Coord Location { get; }
    public Coord Target { get; }
    public abstract int DepthChange { get; }
    public abstract PortalType Type { get; }

    protected DonutPortal(string name, Coord location, Coord target)
    {
        Name = name;
        Location = location;
        Target = target;
    }
}