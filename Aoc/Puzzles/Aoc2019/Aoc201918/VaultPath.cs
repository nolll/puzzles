using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

public class VaultPath
{
    private readonly IList<char> _keysNeeded;

    public int StepCount { get; }
    public VaultKey Target { get; }
    public IList<Coord> Coords { get; }

    public VaultPath(VaultKey target, IList<Coord> coords, IList<char> keysNeeded)
    {
        Target = target;
        Coords = coords;
        StepCount = coords.Count;
        _keysNeeded = keysNeeded;
    }

    public bool IsOpen(IList<VaultKey> collectedKeys)
    {
        return _keysNeeded.All(key => collectedKeys.Any(o => o.Id == key));
    }
}