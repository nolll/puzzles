using Core.Tools;

namespace Core.DonutMaze
{
    public class DonutPortal
    {
        public string Name { get; }
        public MatrixAddress Address { get; }

        public DonutPortal(string name, MatrixAddress address)
        {
            Name = name;
            Address = address;
        }
    }
}