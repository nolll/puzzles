using System;

namespace Aoc.Puzzles.Aoc2018.Aoc201825;

public class Point4d
{
    public int W { get; }
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Point4d(int w, int x, int y, int z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    public int ManhattanDistanceTo(Point4d other) => ManhattanDistanceTo(other.W, other.X, other.Y, other.Z);
    private int ManhattanDistanceTo(int w, int x, int y, int z) => GetDistance(W, w) + GetDistance(X, x) + GetDistance(Y, y) + GetDistance(Z, z);
    private int GetDistance(int a, int b) => Math.Max(a, b) - Math.Min(a, b);
}