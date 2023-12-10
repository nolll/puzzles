using Pzl.Common;
using Spectre.Console;

namespace Pzl.Client.Running.Runners;

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

    public void Run(List<PuzzleDefinition> puzzles)
    {
        var count = puzzles.Count;

        if (count == 0)
        {
            AnsiConsole.WriteLine("No puzzles found.");
            return;
        }

        if (count == 1)
            new StandaloneSinglePuzzleRunner(puzzles.First(), _hashSeed, _isDebugMode).Run();
        else
            new MultiPuzzleRunner(puzzles, _puzzleTimeout, _hashSeed, _isDebugMode).Run();
    }
}