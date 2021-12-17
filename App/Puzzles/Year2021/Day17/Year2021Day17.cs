using App.Platform;

namespace App.Puzzles.Year2021.Day17
{
    public class Year2021Day17 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var trickshot = new TrickShot();
            var result = trickshot.GetMaxHeight(new TrickshotTarget(81, 129, -150, -108));

            return new PuzzleResult(result);
        }

        public override PuzzleResult RunPart2()
        {
            return new PuzzleResult(0);
        }
    }
}