using App.Platform;

namespace App.Puzzles.Year2016.Day02
{
    public class Year2016Day02 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var squareCodeFinder = new SquareKeyCodeFinder();
            var squareCode = squareCodeFinder.Find(FileInput);
            return new PuzzleResult(squareCode, "61529");
        }

        public override PuzzleResult RunPart2()
        {
            var diamondCodeFinder = new DiamondKeyCodeFinder();
            var diamondCode = diamondCodeFinder.Find(FileInput);
            return new PuzzleResult(diamondCode, "C2C28");
        }
    }
}