using App.Platform;

namespace App.Puzzles.Year2017.Day02
{
    public class Year2017Day02 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var spreadsheet = new Spreadsheet(FileInput);
            return new PuzzleResult(spreadsheet.ChecksumMaxMin, 42_378);
        }

        public override PuzzleResult RunPart2()
        {
            var spreadsheet = new Spreadsheet(FileInput);
            return new PuzzleResult(spreadsheet.ChecksumDivision, 246);
        }
    }
}