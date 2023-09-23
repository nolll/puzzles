namespace Common.Puzzles;

public abstract class OnePartPuzzle : Puzzle
{
    public abstract PuzzleResult Run();

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { Run };
}