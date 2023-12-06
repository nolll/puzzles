using Pzl.Tools.Puzzles;
using Spectre.Console;

namespace Pzl.Client.Runners;

public class PuzzleRunner
{
    private readonly int _puzzleTimeout;
    private readonly string _hashSeed;
    private readonly bool _isDebugMode;

    public PuzzleRunner(int puzzleTimeout, string hashSeed, bool isDebugMode)
    {
        _puzzleTimeout = puzzleTimeout;
        _hashSeed = hashSeed;
        _isDebugMode = isDebugMode;
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
            new StandaloneSinglePuzzleRunner(enumerable.First(), _hashSeed, _isDebugMode).Run();
        else
            new MultiPuzzleRunner(enumerable, _puzzleTimeout, _hashSeed, _isDebugMode).Run();
    }
}