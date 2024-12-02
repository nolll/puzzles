using Pzl.Client.Debugging;
using Pzl.Client.Running.Results;
using Pzl.Common;
using Spectre.Console;

namespace Pzl.Client.Running.Runners;

public class PuzzleRunner(
    PuzzleFactory puzzleFactory, 
    ResultVerifier resultVerifier, 
    int puzzleTimeout, 
    RunMode runMode)
{
    public void Run(List<PuzzleDefinition> puzzles)
    {
        switch (puzzles.Count)
        {
            case 0:
                AnsiConsole.WriteLine("No puzzles found.");
                break;
            case 1:
                new StandaloneSinglePuzzleRunner(puzzleFactory, resultVerifier, puzzles.First(), runMode).Run();
                break;
            default:
                new MultiPuzzleRunner(puzzleFactory, resultVerifier, puzzles, puzzleTimeout).Run();
                break;
        }
    }
}