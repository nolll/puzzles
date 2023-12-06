namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201910;

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