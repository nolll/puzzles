using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2019.Day18;

public class VaultDoor
{
    public char Id { get; }
    public MatrixAddress Address { get; }

    public VaultDoor(char id, MatrixAddress address)
    {
        Id = id;
        Address = address;
    }
}