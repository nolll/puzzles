using Core.Tools;

namespace Core.DonutMaze
{
    public class OuterDonutPortal : DonutPortal
    {
        public OuterDonutPortal(string name, MatrixAddress location, MatrixAddress target) : base(name, location, target)
        {
        }

        public override int DepthChange => -1;
        public override PortalType Type => PortalType.Outer;
    }
}