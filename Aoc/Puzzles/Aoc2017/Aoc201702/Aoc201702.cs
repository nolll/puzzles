using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201702;

[Name("Corruption Checksum")]
public class Aoc201702(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var spreadsheet = new Spreadsheet(Input);
        return new PuzzleResult(spreadsheet.ChecksumMaxMin, "d61d3967c55f3affc9cb3db5d9bb4c39");
    }

    protected override PuzzleResult RunPart2()
    {
        var spreadsheet = new Spreadsheet(Input);
        return new PuzzleResult(spreadsheet.ChecksumDivision, "cde27fe58ccb82229c3aa108e113d5bb");
    }
}