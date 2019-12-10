using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Asteroids
{
    public class AsteroidDetector
    {
        public Result Detect(string map)
        {
            var matrix = GetAsteroidMatrix(map);
            var list = GetAsteroidList(matrix);
            var (bestAsteroid, rayCount) = GetBestAsteroid(list);

            return new Result(bestAsteroid, rayCount);
        }

        private (Asteroid, int) GetBestAsteroid(IList<Asteroid> list)
        {
            var highestRayCount = 0;
            Asteroid asteroidWithHighestRayCount = null;
            foreach (var asteroid in list)
            {
                var rays = GetRays(asteroid, list);
                var uniqueRayCount = rays.Distinct().Count();
                if (uniqueRayCount > highestRayCount)
                {
                    highestRayCount = uniqueRayCount;
                    asteroidWithHighestRayCount = asteroid;
                }
            }

            return (asteroidWithHighestRayCount, highestRayCount);
        }

        private IList<Ray> GetRays(Asteroid asteroid, IList<Asteroid> list)
        {
            var rays = new List<Ray>();
            foreach (var a in list)
            {
                if(!a.Equals(asteroid))
                    rays.Add(new Ray(asteroid, a));
            }
            return rays;
        }

        private class Ray : IEquatable<Ray>
        {
            public double Angle { get; }

            public Ray(Asteroid from, Asteroid to)
            {
                float xDiff = to.X - from.X;
                float yDiff = to.Y - from.Y;
                Angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
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
                return Equals((Ray) obj);
            }

            public override int GetHashCode()
            {
                return Angle.GetHashCode();
            }
        }

        private IList<IList<Asteroid>> GetAsteroidMatrix(string map)
        {
            var asteroids = new List<IList<Asteroid>>();
            var rows = map.Trim().Split('\n');
            for (var y = 0; y < rows.Length; y++)
            {
                var asteroidRow = new List<Asteroid>();
                var cols = rows[y].ToCharArray();
                for (var x = 0; x < cols.Length; x++)
                {
                    var asteroid = cols[x] == '#' ? new Asteroid(x, y) : null;
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
}