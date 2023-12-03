using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202019;

public class Aoc202019 : AocPuzzle
{
    public override string Name => "Monster Messages";

    protected override PuzzleResult RunPart1()
    {
        var validator = new MonsterImageValidator(InputFile);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "5689e3eed11a233bb204f8f0e2bfe42f");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new MonsterImageValidator(InputFile, true);
        var result = validator.ValidCount();
        return new PuzzleResult(result, "95d28bbc9dd67fbc8d8db74ab2879177");
    }
}