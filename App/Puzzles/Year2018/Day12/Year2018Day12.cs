using App.Platform;

namespace App.Puzzles.Year2018.Day12
{
    public class Year2018Day12 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var spreader = new PlantSpreader(FileInput);
            return new PuzzleResult(spreader.PlantScore20, 1623);
        }

        public override PuzzleResult RunPart2()
        {
            var spreader = new PlantSpreader(FileInput);
            return new PuzzleResult(spreader.PlantScore50B, 1600000000401);
        }
    }
}