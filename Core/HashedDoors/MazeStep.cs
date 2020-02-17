using Core.Tools;

namespace Core.HashedDoors
{
    public class MazeStep
    {
        public MatrixAddress Address { get; }
        public string Path { get; }

        public MazeStep(MatrixAddress address, string path)
        {
            Address = address;
            Path = path;
        }
    }
}