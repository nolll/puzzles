namespace common.Puzzles;

public abstract class TwoPartsPuzzle : Puzzle
{
    public virtual PuzzleResult RunPart1()
    {
        return null;
    }

    public virtual PuzzleResult RunPart2()
    {
        return null;
    }

    public override IList<Func<PuzzleResult>> RunFunctions =>
        new List<Func<PuzzleResult>> { RunPart1, RunPart2 };
}