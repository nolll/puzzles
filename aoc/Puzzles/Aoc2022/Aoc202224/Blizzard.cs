using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202224;

public class Blizzard
{
    public char Direction { get; }
    public MatrixAddress Address { get; }

    public Blizzard(char direction, MatrixAddress address)
    {
        Direction = direction;
        Address = address;
    }
}