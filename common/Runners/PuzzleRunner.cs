using Common.Puzzles;
using Spectre.Console;

namespace Common.Runners;

public class PuzzleRunner
{
    private readonly int _puzzleTimeout;
    private readonly string _hashSeed;

    public PuzzleRunner(int puzzleTimeout, string hashSeed)
    {
        _puzzleTimeout = puzzleTimeout;
        _hashSeed = hashSeed;
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
            new StandaloneSinglePuzzleRunner(enumerable.First(), _hashSeed).Run();
        else
            new MultiPuzzleRunner(enumerable, _puzzleTimeout, _hashSeed).Run();
    }

    public void Run(Puzzle puzzle)
    {
        Run(new List<Puzzle> { puzzle });
    }
}