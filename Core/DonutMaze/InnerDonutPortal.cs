using Core.Tools;

namespace Core.DonutMaze
{
    public class InnerDonutPortal : DonutPortal
    {
        public InnerDonutPortal(string name, MatrixAddress location, MatrixAddress target) : base(name, location, target)
        {
        }

        public override int DepthChange => 1;
        public override PortalType Type => PortalType.Inner;
    }
}