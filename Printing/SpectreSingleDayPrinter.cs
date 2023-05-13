using System;
using Aoc.Platform;
using Spectre.Console;

namespace Aoc.Printing;

public class SpectreSingleDayPrinter : SpectreDayPrinter, ISingleDayPrinter
{
    private const string Divider = "--------------------------------------------------";

    public void PrintDay(DayResult dayResult)
    {
        PrintDayTitle(dayResult.Day);
        PrintPuzzle(1, dayResult.Result1);
        if (dayResult.Result2.Status != PuzzleResultStatus.Empty)
        {
            AnsiConsole.WriteLine();
            PrintPuzzle(2, dayResult.Result2);
        }

        var totalTimeTaken = dayResult.Result1.TimeTaken + dayResult.Result2.TimeTaken;
        PrintDayEnd(dayResult, totalTimeTaken);
    }

    private void PrintPuzzle(int part, TimedPuzzleResult puzzleResult)
    {
        var time = Formatter.FormatTime(puzzleResult.TimeTaken);
        AnsiConsole.WriteLine($"Part {part}: {time}");
        var color = GetColor(puzzleResult);
        AnsiConsole.Markup($"[{color}]{puzzleResult.Answer}[/]");
        AnsiConsole.WriteLine();
    }

    private static void PrintDayTitle(PuzzleDay day)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"Day {day.Day} {day.Year}:");
        if(day.Puzzle.Title != null)
            AnsiConsole.WriteLine(day.Puzzle.Title);
        PrintDivider();
    }

    private void PrintDayEnd(DayResult dayResult, TimeSpan timeTaken)
    {
        PrintDivider();
        if (!string.IsNullOrEmpty(dayResult.Comment))
        {
            AnsiConsole.MarkupLine($"[yellow]{dayResult.Comment}[/]");
            PrintDivider();
        }
        var time = Formatter.FormatTime(timeTaken);
        AnsiConsole.WriteLine(time.PadLeft(Divider.Length));
    }

    private static void PrintDivider()
    {
        AnsiConsole.WriteLine(Divider);
    }
}