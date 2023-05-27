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
    private const int CommentLength = 24;
    private const int TruncatedCommentLength = CommentLength - 3;

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

        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.WriteLine("| day         | part 1     | part 2     | comment                  |");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");

        foreach (var day in days)
        {
            var dayStr = day.Day.ToString().PadLeft(2, '0');
            var dayAndYear = $"Day {dayStr} {day.Year}";
            var fullComment = day.Puzzle.Comment ?? "";
            var comment = fullComment.Length > TruncatedCommentLength
                ? fullComment[..TruncatedCommentLength] + "..."
                : fullComment;
            var paddedComment = comment.PadRight(CommentLength);
            PrintRow(dayAndYear, "", "", paddedComment);
            PuzzleResult part1Result = null;
            var part1Timer = new Timer();
            var part1Time = TimeSpan.Zero;
            var part1Task = Task.Run(() => part1Result = day.Puzzle.RunPart1());
            while (!part1Task.IsCompleted)
            {
                AnsiConsole.Write("\r");
                part1Time = part1Timer.FromStart;
                PrintRow(dayAndYear, Formatter.FormatTime(part1Time), "", paddedComment);
                Thread.Sleep(20);
            }

            var formattedPart1Time = Formatter.FormatTime(part1Time);

            PuzzleResult part2Result = null;
            var part2Timer = new Timer();
            var part2Time = TimeSpan.Zero;
            var part2Task = Task.Run(() => part2Result = day.Puzzle.RunPart2());
            while (!part2Task.IsCompleted)
            {
                AnsiConsole.Write("\r");
                part2Time = part2Timer.FromStart;
                PrintRow(dayAndYear, formattedPart1Time, Formatter.FormatTime(part2Time), paddedComment);
                Thread.Sleep(20);
            }

            var formattedPart2Time = Formatter.FormatTime(part2Time);
            AnsiConsole.WriteLine();
        }

        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }

    private void PrintRow(string dayAndYear, string part1Time, string part2Time, string comment)
    {
        AnsiConsole.Markup($"| {dayAndYear} | {part1Time,-10} | {part2Time,-10} | {comment} |");
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
        var elapsed = TimeSpan.Zero;
        var task = Task.Run(() => result = func(), cancellationToken);
        while (!task.IsCompleted)
        {
            if (_useTimeout && timer.FromStart >= _timeoutTimespan)
            {
                cancellationTokenSource.Cancel();
                break;
            }

            elapsed = timer.FromStart;
            table.Rows.Update(row, col, new Text(Formatter.FormatTime(timer.FromStart)));
            ctx.Refresh();
            Thread.Sleep(20);
        }
        if (cancellationToken.IsCancellationRequested)
            table.Rows.Update(row, col, new Markup($"[red]>{Formatter.FormatTime(_timeoutTimespan)}[/]"));
        else if(result is null)
            table.Rows.Update(row, col, new Text(""));
        else if (result.Status is PuzzleResultStatus.Correct)
            table.Rows.Update(row, col, new Markup($"[green]{Formatter.FormatTime(elapsed)}[/]"));
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            table.Rows.Update(row, col, new Markup($"[red]{Formatter.FormatTime(elapsed)}[/]"));
        else
            table.Rows.Update(row, col, Text.Empty);
        ctx.Refresh();
    }
}