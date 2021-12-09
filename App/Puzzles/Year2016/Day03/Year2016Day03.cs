using App.Platform;

namespace App.Puzzles.Year2016.Day03
{
    public class Year2016Day03 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var validator = new TriangleValidator();
            var horizontalValidCount = validator.GetHorizontalValidCount(FileInput);
            return new PuzzleResult(horizontalValidCount, 982);
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new TriangleValidator();
            var verticalValidCount = validator.GetVerticalValidCount(FileInput);
            return new PuzzleResult(verticalValidCount, 1826);
        }
    }
}