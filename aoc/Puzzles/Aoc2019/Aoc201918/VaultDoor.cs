using Puzzles.common.CoordinateSystems.CoordinateSystem2D;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201918;

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