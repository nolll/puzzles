using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202203;

[Name("Rucksack Reorganization")]
public class Aoc202203 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = Rucksacks.GetPriority1(input);
        return new PuzzleResult(result, "734ddef10b36997c859308e094bc4baf");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var result = Rucksacks.GetPriority2(input);
        return new PuzzleResult(result, "9fd65a1dd39fabc5782fd0b774cda196");
    }
}