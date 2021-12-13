using App.Platform;

namespace App.Puzzles.Year2021.Day13
{
    public class Year2021Day13 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var paper = new TransparentPaper(FileInput);
            var result = paper.DotCountAfterFold(1);

            return new PuzzleResult(result);
        }

        public override PuzzleResult RunPart2()
        {
            return new PuzzleResult(0);
        }
    }
}