namespace Common.Puzzles;

public abstract class TwoPartsPuzzle : Puzzle
{
    protected virtual PuzzleResult RunPart1()
    {
        return null;
    }

    protected virtual PuzzleResult RunPart2()
    {
        return null;
    }

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { RunPart1, RunPart2 };
}