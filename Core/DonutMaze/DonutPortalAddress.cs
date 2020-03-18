using Core.Tools;

namespace Core.DonutMaze
{
    public class DonutPortalAddress
    {
        public string Name { get; }
        public MatrixAddress Address { get; }

        public DonutPortalAddress(string name, MatrixAddress address)
        {
            Name = name;
            Address = address;
        }
    }
}