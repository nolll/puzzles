using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

internal class Brick
{
    public int Id { get; }
    public Matrix3DAddress Bottom { get; private set; }
    public Matrix3DAddress Top { get; private set; }

    public Brick(int id, Matrix3DAddress bottom, Matrix3DAddress top)
    {
        Id = id;
        Bottom = bottom;
        Top = top;
    }

    public bool IsOverlapping(Brick other) =>
        IsOverlapping(Bottom.X, Top.X, other.Bottom.X, other.Top.X) &&
        IsOverlapping(Bottom.Y, Top.Y, other.Bottom.Y, other.Top.Y) &&
        IsOverlapping(Bottom.Z, Top.Z, other.Bottom.Z, other.Top.Z);

    public void MoveUp() => MoveTo(Bottom.Z + 1);
    public void MoveDown() => MoveTo(Bottom.Z - 1);

    private void MoveTo(int zBottom)
    {
        var diff = Top.Z - Bottom.Z;
        Bottom = new Matrix3DAddress(Bottom.X, Bottom.Y, zBottom);
        Top = new Matrix3DAddress(Top.X, Top.Y, zBottom + diff);
    }

    private static bool IsOverlapping(int fromA, int toA, int fromB, int toB)
        => (fromA <= toB && toA >= fromB);
}