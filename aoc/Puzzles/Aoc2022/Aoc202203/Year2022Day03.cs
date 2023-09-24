using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202203;

public class Year2022Day03 : AocPuzzle
{
    public override string Name => "Rucksack Reorganization";

    protected override PuzzleResult RunPart1()
    {
        var result = Rucksacks.GetPriority1(InputFile);
        return new PuzzleResult(result, 8349);
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Rucksacks.GetPriority2(InputFile);
        return new PuzzleResult(result, 2681);
    }
}