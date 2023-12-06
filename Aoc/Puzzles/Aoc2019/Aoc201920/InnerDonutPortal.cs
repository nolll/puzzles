using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

public class InnerDonutPortal : DonutPortal
{
    public InnerDonutPortal(string name, MatrixAddress location, MatrixAddress target) : base(name, location, target)
    {
    }

    public override int DepthChange => 1;
    public override PortalType Type => PortalType.Inner;
}