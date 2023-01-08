using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2022.Day24;

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