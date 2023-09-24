using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2019.Aoc201918;

public class VaultKey
{
    public char Id { get; }
    public MatrixAddress Address { get; }

    public VaultKey(char id, MatrixAddress address)
    {
        Id = id;
        Address = address;
    }
}