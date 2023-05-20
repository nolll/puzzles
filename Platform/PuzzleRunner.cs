using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Spectre.Console.Rendering;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class PuzzleRunner
{
    private readonly ISingleDayPrinter _singleDayPrinter;
    private readonly IMultiDayPrinter _multiDayPrinter;
    private readonly bool _throwExceptions;
    private readonly int _timeout;
    private readonly TimeSpan _timeoutTimespan;
    private readonly bool _useTimeout = false;

    public PuzzleRunner(ISingleDayPrinter singleDayPrinter, IMultiDayPrinter multiDayPrinter, bool throwExceptions = false, int? timeout = null)
    {
        _singleDayPrinter = singleDayPrinter;
        _multiDayPrinter = multiDayPrinter;
        _throwExceptions = throwExceptions;
        _useTimeout = timeout is not null;
        _timeout = timeout ?? 0;
        _timeoutTimespan = TimeSpan.FromSeconds(_timeout);
    }

    public void Run(IList<PuzzleDay> days)
    {
        _multiDayPrinter.PrintHeader();
        foreach (var day in days)
        {
            var result = RunDay(day);
            _multiDayPrinter.PrintDay(result);
        }
        _multiDayPrinter.PrintFooter();
    }

    public void RunWithLiveTable(IList<PuzzleDay> days)
    {
        var table = new Table();
        AnsiConsole.Live(table).Start(ctx =>
        {
            var row = 0;
            table.AddColumn("day");
            table.AddColumn("part 1");
            table.AddColumn("part 2");
            table.AddColumn("comment");
            ctx.Refresh();
            foreach (var day in days)
            {
                Run(day, ctx, table, row);
                row++;
            }
        });
    }

    private void Run(PuzzleDay day, LiveDisplayContext ctx, Table table, int row)
    {
        var dayStr = day.Day.ToString().PadLeft(2, '0');
        var dayAndYear = $"Day {dayStr} {day.Year}";

        table.AddRow(new Text(dayAndYear), Text.Empty, Text.Empty, new Markup($"[yellow]{day.Puzzle.Comment}[/]"));
        Run(day.Puzzle.RunPart1, table, ctx, row, 1);
        Run(day.Puzzle.RunPart2, table, ctx, row, 2);
    }

    private void Run(Func<PuzzleResult> func, Table table, LiveDisplayContext ctx, int row, int col)
    {
        PuzzleResult result = null;
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var task = Task.Run(() => result = func(), cancellationToken);
        var timer = new Timer();
        while (!task.IsCompleted)
        {
            if (_useTimeout && timer.FromStart >= _timeoutTimespan)
            {
                cancellationTokenSource.Cancel();
                break;
            }
            table.Rows.Update(row, col, new Text(Formatter.FormatTime(timer.FromStart)));
            ctx.Refresh();
        }
        if(cancellationToken.IsCancellationRequested)
            table.Rows.Update(row, col, new Markup($"[red]>{Formatter.FormatTime(_timeoutTimespan)}[/]"));
        else if (result.Status is PuzzleResultStatus.Correct)
            table.Rows.Update(row, col, new Markup($"[green]{Formatter.FormatTime(timer.FromStart)}[/]"));
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            table.Rows.Update(row, col, new Markup($"[red]{Formatter.FormatTime(timer.FromStart)}[/]"));
        else
            table.Rows.Update(row, col, Text.Empty);
        ctx.Refresh();
    }

    public void Run(PuzzleDay day)
    {
        var result = RunDay(day);
        _singleDayPrinter.PrintDay(result);
    }

    private DayResult RunDay(PuzzleDay day)
    {
        var p1 = RunPuzzleWithTimer(day.Puzzle.RunPart1, day.Puzzle.IsSlow);
        var p2 = RunPuzzleWithTimer(day.Puzzle.RunPart2, day.Puzzle.IsSlow);

        return new DayResult(day, p1, p2);
    }

    private TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func, bool isSlow)
    {
        var timer = new Timer();
        var result = RunPuzzle(func, isSlow);
        return new TimedPuzzleResult(result, timer.FromStart);
    }
    
    private PuzzleResult RunPuzzle(Func<PuzzleResult> func, bool isSlow)
    {
        PuzzleResult result = null;
        try
        {
            if (isSlow && _useTimeout)
            {
                var task = Task.Run(() => result = func());
                if (!task.Wait(TimeSpan.FromSeconds(_timeout)))
                    return new TimeoutPuzzleResult($"Puzzle failed to finish within {_timeout} seconds");
            }
            else
            {
                result = func();
            }

            return result ?? new MissingPuzzleResult("Puzzle returned null");
        }
        catch (Exception)
        {
            if (_throwExceptions)
                throw;
            return new FailedPuzzleResult("Puzzle failed");
        }
    }
}