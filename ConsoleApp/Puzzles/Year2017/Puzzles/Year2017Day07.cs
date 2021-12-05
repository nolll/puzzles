using Core.RecursiveCircus;

namespace ConsoleApp.Puzzles.Year2017.Puzzles
{
    public class Year2017Day07 : Year2017Day
    {
        public override int Day => 7;

        public override PuzzleResult RunPart1()
        {
            var towers = new RecursiveTowers(FileInput);
            return new PuzzleResult(towers.BottomName, "dgoocsw");
        }

        public override PuzzleResult RunPart2()
        {
            var towers = new RecursiveTowers(FileInput);
            return new PuzzleResult(towers.AdjustedWeight, 1275);
        }
    }
}