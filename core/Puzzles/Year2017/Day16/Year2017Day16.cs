using Core.Platform;

namespace Core.Puzzles.Year2017.Day16;

public class Year2017Day16 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var dancingPrograms1 = new DancingPrograms();
        dancingPrograms1.Dance(FileInput, 1);
        return new PuzzleResult(dancingPrograms1.Programs, "ehdpincaogkblmfj");
    }

    public override PuzzleResult RunPart2()
    {
        var dancingPrograms2 = new DancingPrograms();
        dancingPrograms2.Dance(FileInput, 1_000_000_000);
        return new PuzzleResult(dancingPrograms2.Programs, "bpcekomfgjdlinha");
    }
}