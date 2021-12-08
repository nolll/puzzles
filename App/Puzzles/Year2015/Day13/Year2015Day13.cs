using App.Platform;

namespace App.Puzzles.Year2015.Day13
{
    public class Year2015Day13 : Year2015Day
    {
        public override int Day => 13;

        public override PuzzleResult RunPart1()
        {
            var table = new DinnerTable(FileInput);
            return new PuzzleResult(table.HappinessChange, 618);
        }

        public override PuzzleResult RunPart2()
        {
            var table = new DinnerTable(FileInput, true);
            return new PuzzleResult(table.HappinessChange, 601);
        }
    }
}