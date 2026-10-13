using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Monitoring Station")]
public class Aoc201910 : AocPuzzle
{
    [Puzzle("1ce0626fd555d7e4aa7dfebfe816d1ed")]
    public int Part1(string input)
    {
        var (_, rayCount) = Detect(input);
        return rayCount;
    }

    [Puzzle("5351b6b34f35abf16b9c55c691804327")]
    public int Part2(string input)
    {
        var asteroids = Vaporize(input);
        var asteroid = asteroids[199];
        return asteroid.X * 100 + asteroid.Y;
    }

    public (Asteroid, int) Detect(string data)
    {
        var (bestAsteroid, rayCount, _) = GetBestAsteroid(data);
        return (bestAsteroid, rayCount);
    }

    private static IList<IList<Asteroid?>> GetAsteroidGrid(string map)
    {
        var asteroids = new List<IList<Asteroid?>>();
        var rows = map.Split(LineBreaks.Single);
        for (var y = 0; y < rows.Length; y++)
        {
            var cols = rows[y].Trim().ToCharArray();
            var asteroidRow = cols.Select((t, x) => t != '.' ? new Asteroid(t, x, y) : null).ToList();
            asteroids.Add(asteroidRow);
        }

        return asteroids;
    }

    private static IList<Asteroid> GetAsteroidList(IList<IList<Asteroid?>> grid) => 
        [.. grid.SelectMany(o => o.Where(a => a != null)).Cast<Asteroid>()];

    private (Asteroid asteroid, int uniqueCount, IList<Ray> rays) GetBestAsteroid(string input)
    {
        var grid = GetAsteroidGrid(input);
        var list = GetAsteroidList(grid);
        var highestRayCount = 0;
        IList<Ray> mostRays = new List<Ray>();
        Asteroid? asteroidWithHighestRayCount = null;
        foreach (var asteroid in list)
        {
            var rays = GetRays(asteroid, list).ToList();
            var uniqueRayCount = rays.Distinct().Count();
            if (uniqueRayCount <= highestRayCount)
                continue;

            highestRayCount = uniqueRayCount;
            asteroidWithHighestRayCount = asteroid;
            mostRays = rays;
        }

        return (asteroidWithHighestRayCount!, highestRayCount, mostRays);
    }

    private static IEnumerable<Ray> GetRays(Asteroid asteroid, IList<Asteroid> list) =>
        list.Where(o => !o.Equals(asteroid)).Select(o => new Ray(asteroid, o));

    public record Asteroid(char Name, int X, int Y);

    public IList<Asteroid> Vaporize(string data)
    {
        var rays = GetBestAsteroid(data).rays;
        var destroyOrder = GetDestroyOrder(rays);
        return destroyOrder.Select(o => o.Target).ToList();
    }

    private static IList<Ray> GetDestroyOrder(IList<Ray> rays)
    {
        var destroyList = new List<Ray>();
        var toSort = rays.OrderBy(o => o.Angle).ThenBy(o => o.Distance).ToList();
        while (toSort.Any())
        {
            var item = toSort.First();
            var angle = item.Angle;
            var alignedItems = toSort.Where(o => MathTools.PrettyEqual(o.Angle, angle)).ToList();
            destroyList.Add(alignedItems.First());
            toSort.RemoveAt(0);
            alignedItems.RemoveAt(0);
            foreach (var alignedItem in alignedItems)
            {
                toSort.RemoveAt(0);
                toSort.Add(alignedItem);
            }
        }

        return destroyList;
    }

    public class Ray : IEquatable<Ray>
    {
        public double Angle { get; }
        public double Distance { get; }
        public Asteroid Target { get; }

        public Ray(Asteroid here, Asteroid there)
        {
            Target = there;
            double xDiff = there.X - here.X;
            double yDiff = there.Y - here.Y;
            var angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI + 90;
            Angle = angle < 0 ? angle + 360 : angle;
            Distance = Math.Sqrt(yDiff * yDiff + xDiff * xDiff);
        }

        public bool Equals(Ray? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Angle.Equals(other.Angle);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Ray)obj);
        }

        public override int GetHashCode() => Angle.GetHashCode();
    }
}