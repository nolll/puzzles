using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

public class Hailstone
{
    public long Id { get; }
    
    public double? Slope { get; }
    public long[] Position { get; }
    public long[] Velocity { get; }
    public long X => Position[Dimension.X];
    public long Y => Position[Dimension.Y];
    public long Z => Position[Dimension.Z];
    public long Vx => Velocity[Dimension.X];
    public long Vy => Velocity[Dimension.Y];
    public long Vz => Velocity[Dimension.Z];

    public Hailstone(long id, long x, long y, long z, long vx, long vy, long vz)
    {
        Id = id;
        Position = [x, y, z];
        Velocity = [vx, vy, vz];
        Slope = Vx == 0 ? null : (double)Vy / Vx;
    }

    public string Print()
    {
        return $"{X}, {Y}, {Z} @ {Vx}, {Vy}, {Vz}";
    }

    public Hailstone WithVelocityDelta(long dvx, long dvy) => new(Id, X, Y, Z, Vx + dvx, Vy + dvy, Vz);

    public double TestZ(double time, long deltaVz) => Z + time * (Vz + deltaVz);
    
    public Intersection? IntersectsWith(Hailstone other)
    {
        if (Slope is null || other.Slope is null || Math.Abs(Slope.Value - other.Slope.Value) < 0.1)
            return null;

        var slope = Slope.Value;
        var otherSlope = other.Slope.Value;

        var c = Y - slope * X;
        var otherC = other.Y - otherSlope * other.X;

        var x = (otherC - c) / (slope - otherSlope);
        var t1 = (x - X) / Vx;
        var t2 = (x - other.X) / other.Vx;

        if (t1 < 0 || t2 < 0) 
            return null;

        var y = slope * (x - X) + Y;
        return new Intersection(x, y, t1);
    }
}