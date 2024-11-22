using System.Diagnostics;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

[DebuggerDisplay("{X},{Y}")]
public class Point(double x, double y)
{
    public double X { get; } = x;
    public double Y { get; } = y;
}