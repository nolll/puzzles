using System;
using System.Threading;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class StandaloneSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly PuzzleDay _day;
    private const int StatusPadding = 15;

    public StandaloneSinglePuzzleRunner(PuzzleDay day)
    {
        _day = day;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_day);
        AnsiConsole.WriteLine();
        RunAndPrintPuzzleResult(1, () => _day.Puzzle.RunPart1());
        AnsiConsole.WriteLine();
        RunAndPrintPuzzleResult(2, () => _day.Puzzle.RunPart2());
        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteHeader(PuzzleDay day)
    {
        AnsiConsole.WriteLine($"Day {day.Day} {day.Year}:");
        if (day.Puzzle.Title is not null)
            AnsiConsole.WriteLine(day.Puzzle.Title);
        if (day.Puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{day.Puzzle.Comment}[/]");
    }

    private void RunAndPrintPuzzleResult(int puzzleNumber, Func<PuzzleResult> puzzleFunc)
    {
        var result = RunPuzzle(puzzleNumber, puzzleFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private PuzzleResult RunPuzzle(int puzzleNumber, Func<PuzzleResult> puzzleFunc)
    {
        PuzzleResult result = null;
        PrintTime(puzzleNumber); 
        var timer = new Timer();
        var task = Task.Run(() => result = puzzleFunc());
        while (!task.IsCompleted)
        {
            PrintTime(puzzleNumber, timer.FromStart);
            Thread.Sleep(ProgressWaitTime);
        }

        return result;
    }

    private void PrintTime(int puzzleNumber, TimeSpan? time = null)
    {
        var formattedTime = time is not null
            ? Formatter.FormatTime(time.Value)
            : string.Empty;

        AnsiConsole.Write($"\rPart {puzzleNumber}: {formattedTime}".PadRight(StatusPadding));
    }
    
    private void WriteAnswer(PuzzleResult result)
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