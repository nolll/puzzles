using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202203;

public class Aoc202203 : AocPuzzle
{
    public override string Name => "Rucksack Reorganization";

    protected override PuzzleResult RunPart1()
    {
        var result = Rucksacks.GetPriority1(InputFile);
        return new PuzzleResult(result, "734ddef10b36997c859308e094bc4baf");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Rucksacks.GetPriority2(InputFile);
        return new PuzzleResult(result, "9fd65a1dd39fabc5782fd0b774cda196");
    }
}