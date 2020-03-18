using Core.Tools;

namespace Core.DonutMaze
{
    public class DonutPortal
    {
        public string Name { get; }
        public MatrixAddress Target { get; }
        public int DepthChange { get; }

        public DonutPortal(string name, MatrixAddress target, int depthChange)
        {
            Name = name;
            Target = target;
            DepthChange = depthChange;
        }
    }
}