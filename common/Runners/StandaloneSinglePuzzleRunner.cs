using Common.Formatting;
using Common.Puzzles;
using Spectre.Console;
using Timer = Common.Timing.Timer;
using Color = System.Drawing.Color;

namespace Common.Runners;

public class StandaloneSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly PuzzleWrapper _wrapper;
    private const int StatusPadding = 15;

    public StandaloneSinglePuzzleRunner(PuzzleWrapper wrapper)
    {
        _wrapper = wrapper;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_wrapper);

        for (var i = 0; i < _wrapper.Puzzle.RunFunctions.Count; i++)
        {
            var runFunc = _wrapper.Puzzle.RunFunctions[i];
            AnsiConsole.WriteLine();
            RunAndPrintPuzzleResult(i + 1, runFunc);
        }

        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteHeader(PuzzleWrapper wrapper)
    {
        AnsiConsole.WriteLine($"{wrapper.Title}:");
        AnsiConsole.WriteLine(wrapper.Puzzle.Name);
        if (wrapper.Puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{wrapper.Puzzle.Comment}[/]");
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
            AnsiConsole.WriteLine();
    }
}