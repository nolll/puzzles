namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

public static class MatrixExtensions
{
    public static void Deconstruct(this MatrixAddress coord, out int x, out int y)
    {
        x = coord.X;
        y = coord.Y;
    }
}