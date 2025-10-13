using Pzl.Tools.Grids.Grids3d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202322;

internal class Brick(int id, Matrix3DAddress bottom, Matrix3DAddress top)
{
    public int Id { get; } = id;
    public Matrix3DAddress Bottom { get; private set; } = bottom;
    public Matrix3DAddress Top { get; private set; } = top;
    public bool CanBeRemoved { get; set; }
    public HashSet<int> Supporting { get; } = new();
    public HashSet<int> SupportedBy { get; } = new();

    public bool IsSupporting(Brick other) =>
        IsOverlapping(Bottom.X, Top.X, other.Bottom.X, other.Top.X) &&
        IsOverlapping(Bottom.Y, Top.Y, other.Bottom.Y, other.Top.Y) &&
        IsOverlapping(Bottom.Z, Top.Z, other.Bottom.Z - 1, other.Top.Z - 1);

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
