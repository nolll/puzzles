using System;
using Core.Asteroids;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day10 : Day2019
    {
        public Day10() : base(10)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var detector = new AsteroidDetector();
            var detectorResult = detector.Detect(FileInput);

            Console.WriteLine($"Asteroid count: {detectorResult.RayCount}");

            WritePartTitle();
            var vaporizer = new AsteroidVaporizer();
            var vaporizeResult = vaporizer.Vaporize(FileInput);
            var asteroidNr200 = vaporizeResult.DestroyedAsteroids[199];
            var result = asteroidNr200.X * 100 + asteroidNr200.Y;

            Console.WriteLine($"X * 100 + Y = {result}");
        }
    }
}