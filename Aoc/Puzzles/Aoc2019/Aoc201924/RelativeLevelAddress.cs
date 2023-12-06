using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class RelativeLevelAddress
{
    public int RelativeLevel { get; }
    public MatrixAddress Address { get; }

    public RelativeLevelAddress(int relativeLevel, MatrixAddress address)
    {
        RelativeLevel = relativeLevel;
        Address = address;
    }
}