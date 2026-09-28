using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Monitoring Station")]
public class Aoc201910 : AocPuzzle
{
    [Puzzle("1ce0626fd555d7e4aa7dfebfe816d1ed")]
    public int Part1(string input) => new AsteroidDetector().Detect(input).RayCount;

    [Puzzle("5351b6b34f35abf16b9c55c691804327")]
    public int Part2(string input)
    {
        var vaporizer = new AsteroidVaporizer();
        var vaporizeResult = vaporizer.Vaporize(input);
        var asteroid = vaporizeResult.DestroyedAsteroids[199];
        return asteroid.X * 100 + asteroid.Y;
    }
    
    public class AsteroidDetector
    {
        public Result Detect(string data)
        {
            var map = new AsteroidMap(data);
            var (bestAsteroid, rayCount, rays) = map.GetBestAsteroid();

            return new Result(bestAsteroid, rayCount);
        }

        public class Result
        {
            public Asteroid BestAsteroid { get; }
            public int RayCount { get; }

            public Result(Asteroid bestAsteroid, int rayCount)
            {
                BestAsteroid = bestAsteroid;
                RayCount = rayCount;
            }
        }
    }
    
    public class Asteroid(char name, int x, int y) : IEquatable<Asteroid>
    {
        public char Name { get; } = name;
        public int X { get; } = x;
        public int Y { get; } = y;

        public bool Equals(Asteroid? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Asteroid) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
    
    public class AsteroidMap
    {
        private readonly IList<Asteroid> _list;

        public AsteroidMap(string data)
        {
            var grid = GetAsteroidGrid(data);
            _list = GetAsteroidList(grid);
        }

        private IList<IList<Asteroid?>> GetAsteroidGrid(string map)
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

        private static IList<Asteroid> GetAsteroidList(IList<IList<Asteroid?>> grid)
        {
            var list = new List<Asteroid>();
            foreach (var row in grid)
            {
                list.AddRange(row.Where(o => o != null).Cast<Asteroid>());
            }

            return list;
        }

        public (Asteroid asteroid, int uniqueCount, IList<Ray> rays) GetBestAsteroid()
        {
            var highestRayCount = 0;
            IList<Ray> mostRays = new List<Ray>();
            Asteroid? asteroidWithHighestRayCount = null;
            foreach (var asteroid in _list)
            {
                var rays = GetRays(asteroid, _list).ToList();
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
    }
    
    public class AsteroidVaporizer
    {
        public Result Vaporize(string data)
        {
            var map = new AsteroidMap(data);
            var rays = map.GetBestAsteroid().rays;
            var destroyOrder = GetDestroyOrder(rays);
            var destroyedAsteroids = destroyOrder.Select(o => o.Target).ToList();
            
            return new Result(destroyedAsteroids);
        }

        private IList<Ray> GetDestroyOrder(IList<Ray> rays)
        {
            var destroyList = new List<Ray>();
            var toSort = rays.OrderBy(o => o.Angle).ThenBy(o => o.Distance).ToList();
            while (toSort.Any())
            {
                var item = toSort.First();
                var angle = item.Angle;
                var alignedItems = toSort.Where(o => o.Angle == angle).ToList();
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

        public class Result
        {
            public IList<Asteroid> DestroyedAsteroids { get; }

            public Result(IList<Asteroid> destroyedAsteroids)
            {
                DestroyedAsteroids = destroyedAsteroids;
            }
        }
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
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ray)obj);
        }

        public override int GetHashCode()
        {
            return Angle.GetHashCode();
        }
    }
}