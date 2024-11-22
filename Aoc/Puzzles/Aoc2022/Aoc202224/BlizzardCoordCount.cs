using System.Diagnostics;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

[DebuggerDisplay("{X},{Y},{Count}")]
public class BlizzardCoordCount
{
    public MatrixAddress Coord { get; }
    public int Count { get; }

    public int X => Coord.X;
    public int Y => Coord.Y;

    public BlizzardCoordCount(MatrixAddress coord, int count)
    {
        Coord = coord;
        Count = count;
    }
}