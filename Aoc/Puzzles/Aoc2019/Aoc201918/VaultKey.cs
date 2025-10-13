using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

public class VaultKey
{
    public char Id { get; }
    public Coord Address { get; }

    public VaultKey(char id, Coord address)
    {
        Id = id;
        Address = address;
    }
}