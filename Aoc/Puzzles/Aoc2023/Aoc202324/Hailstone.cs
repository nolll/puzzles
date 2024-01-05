using Pzl.Tools.CoordinateSystems.CoordinateSystem3D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202324;

public class Hailstone
{
    public long Id { get; }
    
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
    }
}