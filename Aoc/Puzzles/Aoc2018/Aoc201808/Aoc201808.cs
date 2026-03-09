using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201808;

[Name("Memory Maneuver")]
public class Aoc201808 : AocPuzzle
{
    [Puzzle("9c669208d829c31c0fdab74511ee9b14")]
    public int Part1(string input) => new LicenseNumberCalculator(input).MetadataSum;

    [Puzzle("67f685a992923369c5d0aca6b658a5d0")]
    public int Part2(string input) => new LicenseNumberCalculator(input).RootNodeValue;
}