using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day03;

public class Year2022Day03 : AocPuzzle
{
    public override string Name => "Rucksack Reorganization";

    public override PuzzleResult RunPart1()
    {
        var result = Rucksacks.GetPriority1(FileInput);
        return new PuzzleResult(result, 8349);
    }

    public override PuzzleResult RunPart2()
    {
        var result = Rucksacks.GetPriority2(FileInput);
        return new PuzzleResult(result, 2681);
    }
}