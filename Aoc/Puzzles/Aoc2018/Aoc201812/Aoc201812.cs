using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201812;

[Name("Subterranean Sustainability")]
public class Aoc201812 : AocPuzzle
{
    [Puzzle("0ed64899552ad3524168fa5d31b0aa8b")]
    public int Part1(string input) => new PlantSpreader(input).PlantScore20;

    [Puzzle("7efddf05168f7291240396f1a5263653")]
    public long Part2(string input) => new PlantSpreader(input).PlantScore50B;
}