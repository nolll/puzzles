using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2019.Day10
{
    public class AsteroidMap
    {
        private readonly IList<Asteroid> _list;

        public AsteroidMap(string data)
        {
            var matrix = GetAsteroidMatrix(data);
            _list = GetAsteroidList(matrix);
        }

        private IList<IList<Asteroid>> GetAsteroidMatrix(string map)
        {
            var asteroids = new List<IList<Asteroid>>();
            var rows = PuzzleInputReader.ReadLines(map);
            for (var y = 0; y < rows.Count; y++)
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
            foreach (var asteroid in _list)
            {
                var rays = GetRays(asteroid, _list);
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