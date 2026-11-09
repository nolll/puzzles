using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Tools.Grids;

public static class HexagonalGrid
{
    public static Coord UpLeft(Coord coord) => coord.Add(-1, -1);
    public static Coord UpRight(Coord coord) => coord.Add(1, -1);
    public static Coord Right(Coord coord) => coord.Add(2, 0);
    public static Coord DownRight(Coord coord) => coord.Add(1, 1);
    public static Coord DownLeft(Coord coord) => coord.Add(-1, 1);
    public static Coord Left(Coord coord) => coord.Add(-2, 0);
}