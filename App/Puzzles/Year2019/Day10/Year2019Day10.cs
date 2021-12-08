using App.Platform;

namespace App.Puzzles.Year2019.Day10
{
    public class Year2019Day10 : Year2019Day
    {
        public override int Day => 10;

        public override PuzzleResult RunPart1()
        {
            var detector = new AsteroidDetector();
            var detectorResult = detector.Detect(FileInput);

            return new PuzzleResult(detectorResult.RayCount, 340);
        }

        public override PuzzleResult RunPart2()
        {
            var vaporizer = new AsteroidVaporizer();
            var vaporizeResult = vaporizer.Vaporize(FileInput);
            var asteroidNr200 = vaporizeResult.DestroyedAsteroids[199];
            var result = asteroidNr200.X * 100 + asteroidNr200.Y;

            return new PuzzleResult(result, 2628);
        }
    }
}