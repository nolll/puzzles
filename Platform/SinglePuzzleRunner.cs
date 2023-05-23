using System;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class SinglePuzzleRunner
{
    private const string Divider = "--------------------------------------------------";
    private const int StatusPadding = 15;

    public void Run(PuzzleDay day)
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(day);
        AnsiConsole.WriteLine(Divider);
        var part1Time = RunAndPrintPuzzleResult(1, day.Puzzle.RunPart1);
        AnsiConsole.WriteLine();
        var part2Time = RunAndPrintPuzzleResult(2, day.Puzzle.RunPart2);
        AnsiConsole.WriteLine(Divider);
        WriteFooter(part1Time + part2Time);
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

    private TimeSpan RunAndPrintPuzzleResult(int puzzleNumber, Func<PuzzleResult> puzzleFunc)
    {
        var timer = new Timer();
        var result = RunPuzzle(puzzleNumber, puzzleFunc, timer);
        var time = timer.FromStart;
        AnsiConsole.WriteLine();
        WriteAnswer(result);

        return time;
    }

    private PuzzleResult RunPuzzle(int puzzleNumber, Func<PuzzleResult> puzzleFunc, Timer timer)
    {
        PuzzleResult result = null;
        var task = Task.Run(() => result = puzzleFunc());
        AnsiConsole.Write($"\rPart {puzzleNumber}:".PadRight(StatusPadding));
        while (!task.IsCompleted)
        {
            AnsiConsole.Write($"\rPart {puzzleNumber}: {Formatter.FormatTime(timer.FromStart)}".PadRight(StatusPadding));
        }

        return result;
    }

    private static void WriteFooter(TimeSpan totalTime)
    {
        var time = Formatter.FormatTime(totalTime);
        AnsiConsole.WriteLine(time.PadLeft(Divider.Length));
    }

    private void WriteAnswer(PuzzleResult result)
    {
        if (result is null)
            AnsiConsole.MarkupLine("[red]Missing[/]");
        else if (result.Status is PuzzleResultStatus.Empty)
            AnsiConsole.WriteLine("No puzzle");
        else if (result.Status is PuzzleResultStatus.Correct)
            AnsiConsole.MarkupLine($"[green]{result.Answer}[/]");
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            AnsiConsole.MarkupLine($"[red]{result.Answer}[/]");
        else
            AnsiConsole.WriteLine();
    }
}