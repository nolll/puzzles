using System;
using Core.Asteroids;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day10 : Day2019
    {
        public Day10() : base(10)
        {
        }

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