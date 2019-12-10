using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Asteroids
{
    public class AsteroidVaporizer
    {
        public Result Vaporize(string data)
        {
            var map = new AsteroidMap(data);
            var rays = map.GetBestAsteroid().rays;
            //var sortedRays = rays.OrderBy(o => o.Angle).ThenBy(o => o.Distance).ToList();
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

        public bool Equals(Ray other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Angle.Equals(other.Angle);
        }

        public override bool Equals(object obj)
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

    public class AsteroidMap
    {
        private IList<IList<Asteroid>> _matrix;
        public IList<Asteroid> List { get; }

        public AsteroidMap(string data)
        {
            var matrix = GetAsteroidMatrix(data);
            List = GetAsteroidList(matrix);
        }

        private IList<IList<Asteroid>> GetAsteroidMatrix(string map)
        {
            var asteroids = new List<IList<Asteroid>>();
            var rows = map.Trim().Split('\n');
            for (var y = 0; y < rows.Length; y++)
            {
                var asteroidRow = new List<Asteroid>();
                var cols = rows[y].Trim().ToCharArray();
                for (var x = 0; x < cols.Length; x++)
                {
                    var asteroid = cols[x] != '.' ? new Asteroid(cols[x], x, y) : null;
                    asteroidRow.Add(asteroid);
                }
                asteroids.Add(asteroidRow);
            }

            return asteroids;
        }

        private IList<Asteroid> GetAsteroidList(IList<IList<Asteroid>> matrix)
        {
            var list = new List<Asteroid>();
            foreach (var row in matrix)
            {
                list.AddRange(row.Where(o => o != null));
            }

            return list;
        }

        public (Asteroid asteroid, int uniqueCount, IList<Ray> rays) GetBestAsteroid()
        {
            var highestRayCount = 0;
            IList<Ray> mostRays = new List<Ray>();
            Asteroid asteroidWithHighestRayCount = null;
            foreach (var asteroid in List)
            {
                var rays = GetRays(asteroid, List);
                var uniqueRayCount = rays.Distinct().Count();
                if (uniqueRayCount > highestRayCount)
                {
                    highestRayCount = uniqueRayCount;
                    asteroidWithHighestRayCount = asteroid;
                    mostRays = rays;
                }
            }

            return (asteroidWithHighestRayCount, highestRayCount, mostRays);
        }

        private IList<Ray> GetRays(Asteroid asteroid, IList<Asteroid> list)
        {
            var rays = new List<Ray>();
            foreach (var a in list)
            {
                if (!a.Equals(asteroid))
                    rays.Add(new Ray(asteroid, a));
            }
            return rays;
        }
    }
}
