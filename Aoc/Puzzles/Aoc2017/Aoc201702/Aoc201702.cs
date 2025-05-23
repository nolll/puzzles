using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201702;

[Name("Corruption Checksum")]
public class Aoc201702 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var spreadsheet = new Spreadsheet(input);
        return new PuzzleResult(spreadsheet.ChecksumMaxMin, "d61d3967c55f3affc9cb3db5d9bb4c39");
    }

    public PuzzleResult RunPart2(string input)
    {
        var spreadsheet = new Spreadsheet(input);
        return new PuzzleResult(spreadsheet.ChecksumDivision, "cde27fe58ccb82229c3aa108e113d5bb");
    }
}