using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201617;

public class MazeStep
{
    public Coord Address { get; }
    public string Path { get; }

    public MazeStep(Coord address, string path)
    {
        Address = address;
        Path = path;
    }
}