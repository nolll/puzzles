using System;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class SinglePuzzleRunner
{
    private const string Divider = "--------------------------------------------------";

    public void Run(PuzzleDay day)
    {
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"Day {day.Day} {day.Year}:");
        if (day.Puzzle.Title is not null)
            AnsiConsole.WriteLine(day.Puzzle.Title);
        if (day.Puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{day.Puzzle.Comment}[/]");

        AnsiConsole.WriteLine(Divider);

        PuzzleResult result1 = null;
        var task1 = Task.Run(() => result1 = day.Puzzle.RunPart1());
        var timer1 = new Timer();
        AnsiConsole.Write("               ");
        while (!task1.IsCompleted)
        {
            AnsiConsole.Write($"\rPart 1: {Formatter.FormatTime(timer1.FromStart)}".PadRight(15));
        }

        var part1Time = timer1.FromStart;
        AnsiConsole.WriteLine();

        if (result1.Status is PuzzleResultStatus.Correct)
            AnsiConsole.MarkupLine($"[green]{result1.Answer}[/]");
        else if (result1.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            AnsiConsole.MarkupLine($"[red]{result1.Answer}[/]");
        else
            AnsiConsole.WriteLine();

        AnsiConsole.WriteLine();

        PuzzleResult result2 = null;
        var task2 = Task.Run(() => result2 = day.Puzzle.RunPart2());
        var timer2 = new Timer();
        while (!task2.IsCompleted)
        {
            AnsiConsole.Write($"\rPart 2: {Formatter.FormatTime(timer2.FromStart)}".PadRight(15));
        }

        var part2Time = timer2.FromStart;
        AnsiConsole.WriteLine();
        
        if (result2.Status is PuzzleResultStatus.Correct)
            AnsiConsole.MarkupLine($"[green]{result2.Answer}[/]");
        else if (result2.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            AnsiConsole.MarkupLine($"[red]{result2.Answer}[/]");
        else
            AnsiConsole.WriteLine();
        
        AnsiConsole.WriteLine(Divider);

        var totalTime = part1Time + part2Time;
        var time = Formatter.FormatTime(totalTime);
        AnsiConsole.WriteLine(time.PadLeft(Divider.Length));
        AnsiConsole.Cursor.Show(true);
    }
}