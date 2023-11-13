using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201617;

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