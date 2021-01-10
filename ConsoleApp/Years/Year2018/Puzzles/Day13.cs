using System;
using Core.MineCarts;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day13 : Day2018
    {
        private readonly CollisionDetector _detector;

        public Day13() : base(13)
        {
            _detector = new CollisionDetector(FileInput);
        }

        public override PuzzleResult RunPart1()
        {
            _detector.RunCarts();
            var firstCollisionCoords = _detector.LocationOfFirstCollision;
            var firstCollition = $"{firstCollisionCoords.X},{firstCollisionCoords.Y}";
            return new PuzzleResult(firstCollition, "118,112");
        }

        public override PuzzleResult RunPart2()
        {
            var lastCartCoords = _detector.LocationOfLastCart;
            var lastCart = $"{lastCartCoords.X},{lastCartCoords.Y}";
            return new PuzzleResult(lastCart, "50,21");
        }
    }
}