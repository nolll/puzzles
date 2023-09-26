using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202019;

public class Aoc202019 : AocPuzzle
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