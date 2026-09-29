using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("The N-Body Problem")]
public class Aoc201912 : AocPuzzle
{
    [Puzzle("f4aa1e6262770dd457b3fc1a02f903b9")]
    public int Part1(string input, int iterations = 1000) => Run(ReadMap(input), iterations);

    [Puzzle("b61b39d42360ecd83bd6094a285a4251")]
    public long Part2(string input) => RunUntilRepeat(ReadMap(input));

    private static int TotalEnergy(IList<Moon> moons) => moons.Sum(o => o.Energy);

    private int Run(Moon[] moons, int maxIterations)
    {
        var i = 0;
        while (i < maxIterations)
        {
            foreach (var dimension in Dimension.Dimensions)
            {
                UpdateVelocities(moons, dimension);
                Move(moons, dimension);
            }

            i++;
        }

        return TotalEnergy(moons);
    }

    private long RunUntilRepeat(Moon[] moons)
    {
        var iterations = Dimension.Dimensions.Select(_ => (long)0).ToArray();
        foreach (var dimension in Dimension.Dimensions)
        {
            while (!IsDone(moons, dimension))
            {
                UpdateVelocities(moons, dimension);
                Move(moons, dimension);
                iterations[dimension] += 1;
            }
        }

        return MathTools.Lcm(iterations);
    }

    private bool IsDone(Moon[] moons, int dimension) => moons.All(o => o.IsBackAtStart(dimension));

    private void Move(Moon[] moons, int dimension)
    {
        foreach (var moon in moons)
            moon.Move(dimension);
    }

    private void UpdateVelocities(Moon[] moons, int dimension)
    {
        for (var i = 0; i < moons.Length; i++)
        {
            for (var j = 0; j < moons.Length; j++)
            {
                if (i != j)
                    UpdateVelocity(dimension, moons[i], moons[j]);
            }
        }
    }

    private void UpdateVelocity(int dimension, Moon moon, Moon otherMoon)
    {
        var change = GetVelocityChange(moon.Position[dimension], otherMoon.Position[dimension]);
        moon.ChangeVelocity(dimension, moon.Velocity[dimension] + change);
    }

    private static int GetVelocityChange(int moonX, int otherMoonX)
    {
        var diff = otherMoonX - moonX;
        if (diff == 0)
            return 0;

        return diff / Math.Abs(diff);
    }

    private static Moon[] ReadMap(string map)
    {
        var rows = map.Trim().Split(LineBreaks.Single);
        var moons = new List<Moon>();
        foreach (var row in rows)
        {
            var items = row.Trim().TrimStart('<').TrimEnd('>').Replace(" ", "").Split(',');
            var (x, y, z) = items.Select(o => int.Parse(o.Split('=')[1])).ToArray();
            var moon = new Moon(x, y, z);
            moons.Add(moon);
        }

        return [.. moons];
    }

    private class Moon(int x, int y, int z, int vx = 0, int vy = 0, int vz = 0)
    {
        private readonly int[] _startPosition = [x, y, z];
        private readonly bool[] _hasMoved = new bool[3];

        public int[] Position { get; } = [x, y, z];
        public int[] Velocity { get; } = [vx, vy, vz];
        private int X => Position[Dimension.X];
        private int Y => Position[Dimension.Y];
        private int Z => Position[Dimension.Z];
        private int Vx => Velocity[Dimension.X];
        private int Vy => Velocity[Dimension.Y];
        private int Vz => Velocity[Dimension.Z];

        private int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        private int KineticEnergy => Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz);
        public int Energy => PotentialEnergy * KineticEnergy;

        public bool IsBackAtStart(int dimension) =>
            _hasMoved[dimension] &&
            Position[dimension] == _startPosition[dimension]
            && Velocity[dimension] == 0;

        public void ChangeVelocity(int dimension, int velocity) => Velocity[dimension] = velocity;

        public void Move(int dimension)
        {
            Position[dimension] += Velocity[dimension];
            _hasMoved[dimension] = true;
        }
    }
}