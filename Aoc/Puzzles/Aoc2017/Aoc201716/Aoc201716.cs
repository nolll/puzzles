using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201716;

public class Aoc201716 : AocPuzzle
{
    public override string Name => "Permutation Promenade";

    protected override PuzzleResult RunPart1()
    {
        var dancingPrograms1 = new DancingPrograms();
        dancingPrograms1.Dance(InputFile, 1);
        return new PuzzleResult(dancingPrograms1.Programs, "54e5dfe8c4867e76716033345f70c9ad");
    }

    protected override PuzzleResult RunPart2()
    {
        var dancingPrograms2 = new DancingPrograms();
        dancingPrograms2.Dance(InputFile, 1_000_000_000);
        return new PuzzleResult(dancingPrograms2.Programs, "023321046c58453f7009348c8a83a89c");
    }
}