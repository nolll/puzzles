using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Particle Swarm")]
public class Aoc201720 : AocPuzzle
{
    [Puzzle("f5c83f45c41d2ac489cf09ad0e9fb299")]
    public int Part1(string input) => GetClosestParticleInTheLongRunSimple(input);

    [Puzzle("ad8cf8aeb67231056821e6658af28967")]
    public int Part2(string input) => GetRemainingParticleCount(input);

    private IList<Particle> ReadData(string data)
    {
        var rows = data.Split(LineBreaks.Single);
        var particles = new List<Particle>();
        var id = 0;
        foreach (var row in rows)
        {
            var parts = row.Split(", ");
            var p = ReadValues(parts[0]);
            var v = ReadValues(parts[1]);
            var a = ReadValues(parts[2]);
            var particle = new Particle(id, p[0], p[1], p[2], v[0], v[1], v[2], a[0], a[1], a[2]);
            particles.Add(particle);
            id++;
        }

        return particles;
    }

    private static int[] ReadValues(string s) => s.TrimEnd('>').Split('<')[1]
        .Split(',')
        .Select(int.Parse)
        .ToArray();
    
    public int GetRemainingParticleCount(string input)
    {
        var i = 0;
        const int maxIterations = 100;
        var particles = ReadData(input);
        while (i < maxIterations)
        {
            Run(particles);
            particles = particles.Where(particle => particles.Count(o => o.IsColliding(particle)) == 1).ToList();
            i++;
        }

        return particles.Count;
    }

    public int GetClosestParticleInTheLongRunSimple(string input) => ReadData(input)
        .OrderBy(o => Math.Abs(o.Ax) + Math.Abs(o.Ay) + Math.Abs(o.Az))
        .First().Id;

    private void Run(IList<Particle> particles)
    {
        UpdateVelocities(particles);
        Move(particles);
    }

    private void Move(IList<Particle> particles)
    {
        foreach (var p in particles)
            p.Move();
    }

    private void UpdateVelocities(IList<Particle> particles)
    {
        foreach (var p in particles)
            p.ChangeVelocity();
    }

    public class Particle(int id, int x, int y, int z, int vx, int vy, int vz, int ax, int ay, int az)
    {
        public int Id { get; } = id;

        private int[] Position { get; } = [x, y, z];
        private int[] Velocity { get; } = [vx, vy, vz];
        private int[] Acceleration { get; } = [ax, ay, az];
        private int X => Position[Dimension.X];
        private int Y => Position[Dimension.Y];
        private int Z => Position[Dimension.Z];
        public int Ax => Acceleration[Dimension.X];
        public int Ay => Acceleration[Dimension.Y];
        public int Az => Acceleration[Dimension.Z];

        public void ChangeVelocity()
        {
            foreach (var dimension in Dimension.Dimensions) 
                ChangeVelocity(dimension);
        }

        private void ChangeVelocity(int dimension) => Velocity[dimension] += Acceleration[dimension];

        public void Move()
        {
            foreach (var dimension in Dimension.Dimensions) 
                Move(dimension);
        }

        private void Move(int dimension) => Position[dimension] += Velocity[dimension];
        public bool IsColliding(Particle other) => X == other.X && Y == other.Y && Z == other.Z;
    }
}