using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2019.Day18;

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