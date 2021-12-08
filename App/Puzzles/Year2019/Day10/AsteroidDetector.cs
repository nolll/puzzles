namespace App.Puzzles.Year2019.Day10
{
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
}
