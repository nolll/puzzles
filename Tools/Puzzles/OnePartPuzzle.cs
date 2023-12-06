namespace Pzl.Tools.Puzzles;

public abstract class OnePartPuzzle : Puzzle
{
    protected abstract PuzzleResult Run();

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { Run };
}