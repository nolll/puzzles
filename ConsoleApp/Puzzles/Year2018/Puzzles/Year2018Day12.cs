using Core.SubterraneanSustainability;

namespace ConsoleApp.Puzzles.Year2018.Puzzles
{
    public class Year2018Day12 : Year2018Day
    {
        public override int Day => 12;

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