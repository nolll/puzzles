using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201924;

public class RelativeLevelAddress
{
    public int RelativeLevel { get; }
    public Coord Address { get; }

    public RelativeLevelAddress(int relativeLevel, Coord address)
    {
        RelativeLevel = relativeLevel;
        Address = address;
    }
}