using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Maths;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("The N-Body Problem")]
public class Aoc201912 : AocPuzzle
{
    private const int Iterations = 1000;

    [Puzzle("f4aa1e6262770dd457b3fc1a02f903b9")]
    public int Part1(string input)
    {
        var tracker1 = new MoonTracker(input);
        tracker1.Run(Iterations);

        return tracker1.TotalEnergy;
    }

    [Puzzle("b61b39d42360ecd83bd6094a285a4251")]
    public long Part2(string input)
    {
        var tracker2 = new MoonTracker(input);
        tracker2.RunUntilRepeat();

        return tracker2.Iterations;
    }

    public class MoonTracker
    {
        public IList<Moon> Moons { get; }
        public long Iterations { get; private set; }
        public int TotalEnergy => Moons.Sum(o => o.TotalEnergy);

        public MoonTracker(string map)
        {
            Moons = ReadMap(map);
        }

        private IList<Moon> ReadMap(string map)
        {
            var rows = map.Trim().Split('\n');
            var moons = new List<Moon>();
            foreach (var row in rows)
            {
                var items = row.Trim().TrimStart('<').TrimEnd('>').Replace(" ", "").Split(',');
                var coords = items.Select(o => int.Parse(o.Split('=')[1])).ToArray();
                var moon = new Moon(coords[0], coords[1], coords[2]);
                moons.Add(moon);
            }

            return moons;
        }

        public void Run(int maxIterations)
        {
            while (Iterations < maxIterations)
            {
                foreach (var dimension in Dimension.Dimensions)
                {
                    UpdateVelocities(dimension);
                    Move(dimension);
                }

                Iterations++;
            }
        }

        public void RunUntilRepeat()
        {
            var iterations = Dimension.Dimensions.Select(o => (long)0).ToArray();
            foreach (var dimension in Dimension.Dimensions)
            {
                while (!IsDone(dimension))
                {
                    UpdateVelocities(dimension);
                    Move(dimension);
                    iterations[dimension] += 1;
                }
            }

            Iterations = MathTools.Lcm(iterations);
        }

        private bool IsDone(int dimension) => Moons.All(o => o.IsBackAtStart(dimension));

        private void Move(int dimension)
        {
            foreach (var moon in Moons)
                moon.Move(dimension);
        }

        private void UpdateVelocities(int dimension)
        {
            for (var i = 0; i < Moons.Count; i++)
            {
                for (var j = 0; j < Moons.Count; j++)
                {
                    if (i != j)
                        UpdateVelocity(dimension, Moons[i], Moons[j]);
                }
            }
        }

        private void UpdateVelocity(int dimension, Moon moon, Moon otherMoon)
        {
            var change = GetVelocityChange(moon.Position[dimension], otherMoon.Position[dimension]);
            moon.ChangeVelocity(dimension, moon.Velocity[dimension] + change);
        }

        private int GetVelocityChange(int moonX, int otherMoonX)
        {
            var diff = otherMoonX - moonX;
            if (diff == 0)
                return 0;

            return diff / Math.Abs(diff);
        }
    }
    
    public class Velocity
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public int KineticEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        public Velocity(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    
    public class Moon
    {
        private readonly int[] _startPosition;
        private readonly bool[] _hasMoved;

        public int[] Position { get; }
        public int[] Velocity { get; }
        public int X => Position[Dimension.X];
        public int Y => Position[Dimension.Y];
        public int Z => Position[Dimension.Z];
        public int Vx => Velocity[Dimension.X];
        public int Vy => Velocity[Dimension.Y];
        public int Vz => Velocity[Dimension.Z];

        private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        private int KineticEnergy => Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
        public bool IsBackAtStart(int dimension) =>
            _hasMoved[dimension] &&
            Position[dimension] == _startPosition[dimension]
            && Velocity[dimension] == 0;

        public Moon(int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
        {
            _hasMoved = new bool[3];
            _startPosition = new[] { x, y, z };

            Position = new[] { x, y, z };
            Velocity = new[] { vx, vy, vz };
        }

        public void ChangeVelocity(int dimension, int velocity)
        {
            Velocity[dimension] = velocity;
        }

        public void Move(int dimension)
        {
            Position[dimension] += Velocity[dimension];
            _hasMoved[dimension] = true;
        }
    }
}