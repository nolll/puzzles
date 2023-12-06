using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201702;

public class Aoc201702 : AocPuzzle
{
    public override string Name => "Corruption Checksum";

    protected override PuzzleResult RunPart1()
    {
        var spreadsheet = new Spreadsheet(InputFile);
        return new PuzzleResult(spreadsheet.ChecksumMaxMin, "d61d3967c55f3affc9cb3db5d9bb4c39");
    }

    protected override PuzzleResult RunPart2()
    {
        var spreadsheet = new Spreadsheet(InputFile);
        return new PuzzleResult(spreadsheet.ChecksumDivision, "cde27fe58ccb82229c3aa108e113d5bb");
    }
}