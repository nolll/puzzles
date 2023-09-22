using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day02;

public class Year2017Day02 : AocPuzzle
{
    public override string Name => "Corruption Checksum";

    protected override PuzzleResult RunPart1()
    {
        var spreadsheet = new Spreadsheet(FileInput);
        return new PuzzleResult(spreadsheet.ChecksumMaxMin, 42_378);
    }

    protected override PuzzleResult RunPart2()
    {
        var spreadsheet = new Spreadsheet(FileInput);
        return new PuzzleResult(spreadsheet.ChecksumDivision, 246);
    }
}