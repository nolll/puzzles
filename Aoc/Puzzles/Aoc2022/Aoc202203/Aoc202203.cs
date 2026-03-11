using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202203;

[Name("Rucksack Reorganization")]
public class Aoc202203 : AocPuzzle
{
    [Puzzle("734ddef10b36997c859308e094bc4baf")]
    public int Part1(string input) => Rucksacks.GetPriority1(input);

    [Puzzle("9fd65a1dd39fabc5782fd0b774cda196")]
    public int Part2(string input) => Rucksacks.GetPriority2(input);
}