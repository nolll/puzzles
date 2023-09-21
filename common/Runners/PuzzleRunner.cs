using common.Puzzles;

namespace common.Runners;

public class PuzzleRunner
{
    private readonly int _puzzleTimeout;

    public PuzzleRunner(int puzzleTimeout)
    {
        _puzzleTimeout = puzzleTimeout;
    }

    public void Run(IEnumerable<PuzzleWrapper> wrappers)
    {
        var enumerable = wrappers as PuzzleWrapper[] ?? wrappers.ToArray();
        var count = enumerable.Length;

        if(count == 0)
            throw new Exception("No puzzles found.");

        if (count == 1)
            new StandaloneSinglePuzzleRunner(enumerable.First()).Run();
        else
            new MultiDayPuzzleRunner(_puzzleTimeout).Run(enumerable);
    }

    public void Run(PuzzleWrapper puzzleWrapper)
    {
        Run(new List<PuzzleWrapper> { puzzleWrapper });
    }
}