using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids3d;

[DebuggerDisplay("{X},{Y},{Z}")]
public record Coord3d(int X, int Y, int Z)
{
    public string Id { get; } = $"{X},{Y},{Z}";

    public int ManhattanDistanceTo(Coord3d other) => 
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z);
    
    public double EuclideanDistanceTo(Coord3d other) => 
        Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));

    public override string ToString() => $"{X},{Y},{Z}";
}