using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

public class Blizzard
{
    public char Direction { get; }
    public Coord Address { get; }

    public Blizzard(char direction, Coord address)
    {
        Direction = direction;
        Address = address;
    }
}