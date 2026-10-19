namespace Pzl.Tools.Grids.Grids4d;

public record Coord4d(int X, int Y, int Z, int W)
{
    public string Id { get; } = $"{X},{Y},{Z},{W}";

    public int ManhattanDistanceTo(Coord4d other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z) + Math.Abs(W - other.W);
}