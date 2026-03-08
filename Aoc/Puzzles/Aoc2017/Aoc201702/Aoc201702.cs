using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201702;

[Name("Corruption Checksum")]
public class Aoc201702 : AocPuzzle
{
    [Puzzle("d61d3967c55f3affc9cb3db5d9bb4c39")]
    public int Part1(string input) => new Spreadsheet(input).ChecksumMaxMin;

    [Puzzle("cde27fe58ccb82229c3aa108e113d5bb")]
    public int Part2(string input) => new Spreadsheet(input).ChecksumDivision;
}