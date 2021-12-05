using Core.MineCarts;

namespace ConsoleApp.Puzzles.Year2018.Puzzles.Day13
{
    public class Year2018Day13 : Year2018Day
    {
        private readonly CollisionDetector _detector;

        public override int Day => 13;

        public Year2018Day13()
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