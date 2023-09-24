using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day16;

public class Year2017Day16 : AocPuzzle
{
    public override string Name => "Permutation Promenade";

    protected override PuzzleResult RunPart1()
    {
        var dancingPrograms1 = new DancingPrograms();
        dancingPrograms1.Dance(InputFile, 1);
        return new PuzzleResult(dancingPrograms1.Programs, "ehdpincaogkblmfj");
    }

    protected override PuzzleResult RunPart2()
    {
        var dancingPrograms2 = new DancingPrograms();
        dancingPrograms2.Dance(InputFile, 1_000_000_000);
        return new PuzzleResult(dancingPrograms2.Programs, "bpcekomfgjdlinha");
    }
}