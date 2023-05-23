using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Spectre.Console.Rendering;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class MultiPuzzleRunner
{
    private readonly TimeSpan _timeoutTimespan;
    private readonly bool _useTimeout;

    public MultiPuzzleRunner(int? timeout = null)
    {
        _useTimeout = timeout is not null;
        _timeoutTimespan = TimeSpan.FromSeconds(timeout ?? 0);
    }

    public void Run(IList<PuzzleDay> days)
    {
        var table = new Table();
        AnsiConsole.Live(table).Start(ctx =>
        {
            var row = 0;
            table.AddColumn("day");
            table.AddColumn("part 1");
            table.AddColumn("part 2");
            table.AddColumn("comment");
            foreach (var day in days)
            {
                RunAndPrintRow(day, ctx, table, row);
                row++;
            }
        });
    }

    private void RunAndPrintRow(PuzzleDay day, LiveDisplayContext ctx, Table table, int row)
    {
        var dayStr = day.Day.ToString().PadLeft(2, '0');
        var dayAndYear = $"Day {dayStr} {day.Year}";

        var comment = day.Puzzle.Comment is not null
            ? new Markup($"[yellow]{day.Puzzle.Comment}[/]")
            : (IRenderable)Text.Empty;

        table.AddRow(new Text(dayAndYear), Text.Empty, Text.Empty, comment);
        RunAndPrintCell(day.Puzzle.RunPart1, table, ctx, row, 1);
        RunAndPrintCell(day.Puzzle.RunPart2, table, ctx, row, 2);
    }

    private void RunAndPrintCell(Func<PuzzleResult> func, Table table, LiveDisplayContext ctx, int row, int col)
    {
        PuzzleResult result = null;
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var timer = new Timer();
        var task = Task.Run(() => result = func(), cancellationToken);
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
        if (cancellationToken.IsCancellationRequested)
            table.Rows.Update(row, col, new Markup($"[red]>{Formatter.FormatTime(_timeoutTimespan)}[/]"));
        else if(result is null)
            table.Rows.Update(row, col, new Text(""));
        else if (result.Status is PuzzleResultStatus.Correct)
            table.Rows.Update(row, col, new Markup($"[green]{Formatter.FormatTime(timer.FromStart)}[/]"));
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            table.Rows.Update(row, col, new Markup($"[red]{Formatter.FormatTime(timer.FromStart)}[/]"));
        else
            table.Rows.Update(row, col, Text.Empty);
        ctx.Refresh();
    }
}