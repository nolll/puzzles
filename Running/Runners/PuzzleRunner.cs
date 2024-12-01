using Pzl.Common;
using Spectre.Console;

namespace Pzl.Client.Running.Runners;

public class PuzzleRunner(int puzzleTimeout, string hashSeed, bool isDebugMode)
{
    public void Run(List<PuzzleDefinition> puzzles)
    {
        switch (puzzles.Count)
        {
            case 0:
                AnsiConsole.WriteLine("No puzzles found.");
                break;
            case 1:
                new StandaloneSinglePuzzleRunner(puzzles.First(), hashSeed, isDebugMode).Run();
                break;
            default:
                new MultiPuzzleRunner(puzzles, puzzleTimeout, hashSeed).Run();
                break;
        }
    }
}