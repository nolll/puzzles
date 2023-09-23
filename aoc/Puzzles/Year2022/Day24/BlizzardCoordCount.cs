using System.Diagnostics;
using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2022.Day24;

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