using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2016.Day17
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