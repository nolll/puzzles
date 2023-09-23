using Common.Puzzles;
using Spectre.Console;

namespace Common.Runners;

public class MultiDayPuzzleRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiDayPuzzleRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<Puzzle> puzzles)
    {
        var puzzleList = puzzles.ToList();
        var maxRunFuncCount = puzzleList.Max(o => o.RunFunctions.Count);
        var partTitles = maxRunFuncCount > 1
            ? Enumerable.Range(1, maxRunFuncCount).Select(o => $"part {o}    ")
            : new List<string> { "result    " };
        var variableParts = string.Join(" | ", partTitles);
        
        var partsDividers = maxRunFuncCount > 1
            ? Enumerable.Range(1, maxRunFuncCount).Select(_ => "----------")
            : new List<string> { "----------" };
        var variableDividers = string.Join("---", partsDividers);
        var divider = $"----------------{variableDividers}-----------------------------";

        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine($"Running {puzzleList.Count} puzzles");
        AnsiConsole.WriteLine(divider);
        AnsiConsole.WriteLine($"| puzzle      | {variableParts} | comment                  |");
        AnsiConsole.WriteLine(divider);

        foreach (var puzzle in puzzleList)
        {
            new InSequenceSinglePuzzleRunner(puzzle, _timeoutTimespan).Run();
        }

        AnsiConsole.WriteLine(divider);
        AnsiConsole.Cursor.Show(true);
    }
}