using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Aoc.Printing;
using Spectre.Console;
using Spectre.Console.Rendering;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class SinglePuzzleRunner
{
    private const string Divider = "--------------------------------------------------";
    private readonly ISingleDayPrinter _singleDayPrinter;

    public SinglePuzzleRunner(ISingleDayPrinter singleDayPrinter)
    {
        _singleDayPrinter = singleDayPrinter;
    }
    
    public void Run(PuzzleDay day)
    {
        var result = RunDay(day);
        _singleDayPrinter.PrintDay(result);
    }

    public void RunLive(PuzzleDay day)
    {
        TimeSpan part1Time = TimeSpan.MinValue;
        TimeSpan part2Time = TimeSpan.MinValue;

        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine($"Day {day.Day} {day.Year}:");
        if (day.Puzzle.Title != null)
            AnsiConsole.WriteLine(day.Puzzle.Title);

        AnsiConsole.WriteLine(Divider);

        AnsiConsole.Status().Start("Part 1: 0s", ctx =>
        {
            PuzzleResult result = null;
            var task = Task.Run(() => result = day.Puzzle.RunPart1());
            var timer = new Timer();
            while (!task.IsCompleted)
            {
                ctx.Status($"Part 1: {Formatter.FormatTime(timer.FromStart)}");
                ctx.Refresh();
            }

            part1Time = timer.FromStart;
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine($"Part 1: {Formatter.FormatTime(part1Time)}");
            if (result.Status is PuzzleResultStatus.Correct)
                AnsiConsole.MarkupLine($"[green]{result.Answer}[/]");
            else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
                AnsiConsole.MarkupLine($"[red]{result.Answer}[/]");
            else
                AnsiConsole.WriteLine();
            ctx.Refresh();
        });

        AnsiConsole.Status().Start("Part 2: 0s", ctx =>
        {
            PuzzleResult result = null;
            var task = Task.Run(() => result = day.Puzzle.RunPart2());
            var timer = new Timer();
            while (!task.IsCompleted)
            {
                ctx.Status($"Part 2: {Formatter.FormatTime(timer.FromStart)}");
                ctx.Refresh();
            }

            part2Time = timer.FromStart;
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine($"Part 2: {Formatter.FormatTime(part2Time)}");
            if (result.Status is PuzzleResultStatus.Correct)
                AnsiConsole.MarkupLine($"[green]{result.Answer}[/]");
            else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
                AnsiConsole.MarkupLine($"[red]{result.Answer}[/]");
            else
                AnsiConsole.WriteLine();
            ctx.Refresh();
        });

        AnsiConsole.WriteLine(Divider);

        var totalTime = part1Time + part2Time;
        var time = Formatter.FormatTime(totalTime);
        AnsiConsole.WriteLine(time.PadLeft(Divider.Length));
    }

    private DayResult RunDay(PuzzleDay day)
    {
        var p1 = RunPuzzleWithTimer(day.Puzzle.RunPart1);
        var p2 = RunPuzzleWithTimer(day.Puzzle.RunPart2);

        return new DayResult(day, p1, p2);
    }

    private TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func)
    {
        var timer = new Timer();
        var result = RunPuzzle(func);
        return new TimedPuzzleResult(result, timer.FromStart);
    }
    
    private PuzzleResult RunPuzzle(Func<PuzzleResult> func)
    {
        return func() ?? new MissingPuzzleResult("Puzzle returned null");
    }
}