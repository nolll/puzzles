using Puzzles.Common.CoordinateSystems.CoordinateSystem3D;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201720;

public class Particle
{
    public int Id { get; }
    private readonly int[] _startPosition;
    private readonly bool[] _hasMoved;

    public int[] Position { get; }
    public int[] Velocity { get; }
    public int[] Acceleration { get; }
    public int X => Position[Dimension.X];
    public int Y => Position[Dimension.Y];
    public int Z => Position[Dimension.Z];
    public int Vx => Velocity[Dimension.X];
    public int Vy => Velocity[Dimension.Y];
    public int Vz => Velocity[Dimension.Z];
    public int Ax => Acceleration[Dimension.X];
    public int Ay => Acceleration[Dimension.Y];
    public int Az => Acceleration[Dimension.Z];

    private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
    private int KineticEnergy => Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);

    public int ManhattanDistanceFromOrigo => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
    public int ManhattanX => Math.Abs(X);
    public int ManhattanY => Math.Abs(Y);
    public int ManhattanZ => Math.Abs(Z);

    public int TotalEnergy => PotentialEnergy * KineticEnergy;
    public bool IsBackAtStart(int dimension) =>
        _hasMoved[dimension] &&
        Position[dimension] == _startPosition[dimension]
        && Velocity[dimension] == 0;

    public Particle(int id, int x, int y, int z, int vx, int vy, int vz, int ax, int ay, int az)
    {
        Id = id;
        _hasMoved = new bool[3];
        _startPosition = new[] { x, y, z };

        Position = new[] { x, y, z };
        Velocity = new[] { vx, vy, vz };
        Acceleration = new[] { ax, ay, az };
    }

    public void ChangeVelocity()
    {
        foreach (var dimension in Dimension.Dimensions)
        {
            ChangeVelocity(dimension);
        }
    }

    public void ChangeVelocity(int dimension)
    {
        Velocity[dimension] += Acceleration[dimension];
    }

    public void Move()
    {
        foreach (var dimension in Dimension.Dimensions)
        {
            Move(dimension);
        }
    }

    public void Move(int dimension)
    {
        Position[dimension] += Velocity[dimension];
        _hasMoved[dimension] = true;
    }

    public bool IsColliding(Particle other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }
}