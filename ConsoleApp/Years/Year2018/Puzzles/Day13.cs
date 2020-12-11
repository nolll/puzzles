using System;
using Core.MineCarts;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day13 : Day2018
    {
        public Day13() : base(13)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var detector = new CollisionDetector(FileInput);
            var firstCollisionCoords = detector.LocationOfFirstCollision;
            var firstCollition = $"{firstCollisionCoords.X},{firstCollisionCoords.Y}";
            return new PuzzleResult($"First crash location: {firstCollition}");
        }

        public override PuzzleResult RunPart2()
        {
            var detector = new CollisionDetector(FileInput);
            var lastCartCoords = detector.LocationOfLastCart;
            var lastCart = $"{lastCartCoords.X},{lastCartCoords.Y}";
            return new PuzzleResult($"Last cart location: {lastCart}");
        }
    }
}