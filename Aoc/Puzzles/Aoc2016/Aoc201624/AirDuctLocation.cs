using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201624;

public class AirDuctLocation
{
    public char Id { get; }
    public MatrixAddress Address { get; }

    public AirDuctLocation(char id, MatrixAddress address)
    {
        Id = id;
        Address = address;
    }
}