using Common.Puzzles;
using Spectre.Console;

namespace Common.Runners;

public class PuzzleRunner
{
    private readonly int _puzzleTimeout;

    public PuzzleRunner(int puzzleTimeout)
    {
        _puzzleTimeout = puzzleTimeout;
    }

    public void Run(IEnumerable<Puzzle> puzzles)
    {
        var enumerable = puzzles as Puzzle[] ?? puzzles.ToArray();
        var count = enumerable.Length;

        if (count == 0)
        {
            AnsiConsole.WriteLine("No puzzles found.");
            return;
        }

        if (count == 1)
            new StandaloneSinglePuzzleRunner(enumerable.First()).Run();
        else
            new MultiDayPuzzleRunner(_puzzleTimeout).Run(enumerable);
    }

    public void Run(Puzzle puzzle)
    {
        Run(new List<Puzzle> { puzzle });
    }
}