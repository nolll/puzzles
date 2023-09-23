using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day19;

public class Year2020Day19 : AocPuzzle
{
    public override string Name => "Monster Messages";

    protected override PuzzleResult RunPart1()
    {
        var validator = new MonsterImageValidator(InputFile);
        var result = validator.ValidCount();
        return new PuzzleResult(result, 122);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new MonsterImageValidator(InputFile, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result, 287);
    }
}