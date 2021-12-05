using Core.FloorTraps;

namespace ConsoleApp.Puzzles.Year2016.Day18
{
    public class Year2016Day18 : Year2016Day
    {
        public override int Day => 18;

        public override PuzzleResult RunPart1()
        {
            var detector = new FloorTrapDetector(FileInput);
            var safeCount = detector.CountSafeTiles(40);
            return new PuzzleResult(safeCount, 1989);
        }

        public override PuzzleResult RunPart2()
        {
            var detector = new FloorTrapDetector(FileInput);
            var safeCount = detector.CountSafeTiles(400_000);
            return new PuzzleResult(safeCount, 19_999_894);
        }
    }
}