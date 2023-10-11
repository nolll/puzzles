using Common.Formatting;
using Common.Puzzles;
using Spectre.Console;
using Timer = Common.Timing.Timer;
using Color = System.Drawing.Color;

namespace Common.Runners;

public class StandaloneSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly Puzzle _puzzle;
    private const int StatusPadding = 15;

    public StandaloneSinglePuzzleRunner(Puzzle puzzle)
    {
        _puzzle = puzzle;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_puzzle);

        for (var i = 0; i < _puzzle.RunFunctions.Count; i++)
        {
            var runFunc = _puzzle.RunFunctions[i];
            AnsiConsole.WriteLine();
            RunAndPrintPuzzleResult(i + 1, runFunc);
        }

        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteHeader(Puzzle puzzle)
    {
        AnsiConsole.WriteLine($"{puzzle.Title}:");
        AnsiConsole.WriteLine(puzzle.Name);
        if (puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{puzzle.Comment}[/]");
    }

    private static void RunAndPrintPuzzleResult(int puzzleIndex, Func<PuzzleResult> puzzleFunc)
    {
        var result = RunPuzzle(puzzleIndex, puzzleFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private static PuzzleResult RunPuzzle(int puzzleIndex, Func<PuzzleResult> puzzleFunc)
    {
        PuzzleResult? result = null;
        PrintTime(puzzleIndex); 
        var timer = new Timer();
        var task = Task.Run(() => result = puzzleFunc());
        while (!task.IsCompleted)
        {
            PrintTime(puzzleIndex, timer.FromStart);
            Thread.Sleep(ProgressWaitTime);
        }

        if (task.IsFaulted && task.Exception is not null)
            throw task.Exception;

        return task.IsFaulted ? PuzzleResult.Failed : result ?? PuzzleResult.Empty;
    }

    private static void PrintTime(int puzzleNumber, TimeSpan? time = null)
    {
        var formattedTime = time is not null
            ? Formatter.FormatTime(time.Value)
            : string.Empty;

        AnsiConsole.Write($"\rPart {puzzleNumber}: {formattedTime}".PadRight(StatusPadding));
    }
    
    private static void WriteAnswer(PuzzleResult? result)
    {
        if (result is null)
            AnsiConsole.MarkupLine(MarkupColor("Missing", Color.Red));
        else if (result.Status is PuzzleResultStatus.Empty)
            AnsiConsole.WriteLine("No puzzle");
        else if (result.Status is PuzzleResultStatus.Correct)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Green));
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Red));
        else
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Yellow));
    }
}