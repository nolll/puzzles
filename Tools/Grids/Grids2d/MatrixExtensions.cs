namespace Pzl.Tools.Grids.Grids2d;

public static class MatrixExtensions
{
    public static void Deconstruct(this Coord coord, out int x, out int y)
    {
        x = coord.X;
        y = coord.Y;
    }
}