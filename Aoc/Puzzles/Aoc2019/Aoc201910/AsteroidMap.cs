using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201910;

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