using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201702;

public class Year2017Day02 : AocPuzzle
{
    public override string Name => "Corruption Checksum";

    protected override PuzzleResult RunPart1()
    {
        var spreadsheet = new Spreadsheet(InputFile);
        return new PuzzleResult(spreadsheet.ChecksumMaxMin, 42_378);
    }

    protected override PuzzleResult RunPart2()
    {
        var spreadsheet = new Spreadsheet(InputFile);
        return new PuzzleResult(spreadsheet.ChecksumDivision, 246);
    }
}