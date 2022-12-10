using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day20;

public class InnerDonutPortal : DonutPortal
{
    public InnerDonutPortal(string name, MatrixAddress location, MatrixAddress target) : base(name, location, target)
    {
    }

    public override int DepthChange => 1;
    public override PortalType Type => PortalType.Inner;
}