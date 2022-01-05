using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2019.Day18;

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