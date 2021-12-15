using App.Platform;

namespace App.Puzzles.Year2021.Day15
{
    public class Year2021Day15 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var chitonRisk = new ChitonRisk(FileInput);
            var result = chitonRisk.FindRiskLevel();

            return new PuzzleResult(result, 423);
        }

        public override PuzzleResult RunPart2()
        {
            return new PuzzleResult(0);
        }
    }
}