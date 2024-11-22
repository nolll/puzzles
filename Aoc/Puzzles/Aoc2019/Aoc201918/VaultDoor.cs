using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

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