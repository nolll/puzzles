using App.Platform;

namespace App.Puzzles.Year2018.Day13
{
    public class Year2018Day13 : Puzzle
    {
        private CollisionDetector _detector;

        private CollisionDetector Detector
        {
            get
            {
                if(_detector == null)
                    _detector = new CollisionDetector(FileInput);
                return _detector;
            }
        }
        
        public override PuzzleResult RunPart1()
        {
            Detector.RunCarts();
            var firstCollisionCoords = Detector.LocationOfFirstCollision;
            var firstCollition = $"{firstCollisionCoords.X},{firstCollisionCoords.Y}";
            return new PuzzleResult(firstCollition, "118,112");
        }

        public override PuzzleResult RunPart2()
        {
            var lastCartCoords = Detector.LocationOfLastCart;
            var lastCart = $"{lastCartCoords.X},{lastCartCoords.Y}";
            return new PuzzleResult(lastCart, "50,21");
        }
    }
}