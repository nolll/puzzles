using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Particle Swarm")]
public class Aoc201720 : AocPuzzle
{
    [Puzzle("f5c83f45c41d2ac489cf09ad0e9fb299")]
    public int Part1(string input) => new ParticleTracker(input).GetClosestParticleInTheLongRunSimple();

    [Puzzle("ad8cf8aeb67231056821e6658af28967")]
    public int Part2(string input)
    {
        var tracker = new ParticleTracker(input);
        return tracker.GetRemainingParticleCount();
    }
    
    public class ParticleTracker
    {
        private long _iterations;
        public IList<Particle> Particles { get; private set; }

        public ParticleTracker(string map)
        {
            Particles = ReadData(map);
        }
    
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

        public void Run(int maxIterations)
        {
            while (_iterations < maxIterations)
            {
                Run();
                _iterations++;
            }
        }

        public int GetRemainingParticleCount()
        {
            const int maxIterations = 100;
            while (_iterations < maxIterations)
            {
                Run();
                var particles = Particles.Where(particle => Particles.Count(o => o.IsColliding(particle)) == 1).ToList();
                Particles = particles;
                _iterations++;
            }

            return Particles.Count;
        }

        public int GetClosestParticleInTheLongRunSimple() => Particles
            .OrderBy(o => Math.Abs(o.Ax) + Math.Abs(o.Ay) + Math.Abs(o.Az))
            .First().Id;

        private void Run()
        {
            UpdateVelocities();
            Move();
        }

        private void Move()
        {
            foreach (var p in Particles)
                p.Move();
        }

        private void UpdateVelocities()
        {
            foreach (var p in Particles)
                p.ChangeVelocity();
        }
    }

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
}