using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

public enum PortalType
{
    Inner,
    Outer
}

public abstract class DonutPortal
{
    public string Name { get; }
    public MatrixAddress Location { get; }
    public MatrixAddress Target { get; }
    public abstract int DepthChange { get; }
    public abstract PortalType Type { get; }

    protected DonutPortal(string name, MatrixAddress location, MatrixAddress target)
    {
        Name = name;
        Location = location;
        Target = target;
    }
}