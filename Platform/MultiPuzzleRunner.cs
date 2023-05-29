using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class MultiPuzzleRunner
{
    private const int ResultColumnWidth = 10;
    private const int CommentColumnWidth = 24;
    private const int TruncatedCommentLength = CommentColumnWidth - 3;

    private readonly TimeSpan _timeoutTimespan;
    private readonly bool _useTimeout;

    public MultiPuzzleRunner(int? timeoutSeconds = null)
    {
        _useTimeout = timeoutSeconds is not null;
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds ?? 0);
    }

    public void Run(IEnumerable<PuzzleDay> days)
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
            var commentMarkup = MarkupComment(day.Puzzle.Comment);
            PrintRow(dayAndYear, "", "", commentMarkup);
            var part1Status = PuzzleResultStatus.Empty;
            var part1Timer = new Timer();
            var part1Time = TimeSpan.Zero;
            var waitedPart1 = false;
            var cancellationTokenSourcePart1 = new CancellationTokenSource();
            var cancellationTokenPart1 = cancellationTokenSourcePart1.Token;
            var part1Task = Task.Run(() => part1Status = day.Puzzle.RunPart1().Status, cancellationTokenPart1);
            while (!part1Task.IsCompleted)
            {
                if (_useTimeout && part1Timer.FromStart >= _timeoutTimespan)
                {
                    cancellationTokenSourcePart1.Cancel();
                    part1Status = PuzzleResultStatus.Timeout;
                    break;
                }

                waitedPart1 = true;
                AnsiConsole.Write("\r");
                part1Time = part1Timer.FromStart;
                PrintRow(dayAndYear, Formatter.FormatTime(part1Time).PadRight(10), "".PadRight(10), commentMarkup);
                Thread.Sleep(20);
            }

            part1Time = waitedPart1 ? part1Time : part1Timer.FromStart;
            var formattedPart1Time = MarkupTime(part1Time, part1Status);
            AnsiConsole.Write("\r");
            PrintRow(dayAndYear, formattedPart1Time, "", commentMarkup);

            var part2Status = PuzzleResultStatus.Empty;
            var part2Timer = new Timer();
            var part2Time = TimeSpan.Zero;
            var waitedPart2 = false;
            var cancellationTokenSourcePart2 = new CancellationTokenSource();
            var cancellationTokenPart2 = cancellationTokenSourcePart2.Token;
            var part2Task = Task.Run(() => part2Status = day.Puzzle.RunPart2().Status, cancellationTokenPart2);
            while (!part2Task.IsCompleted)
            {
                if (_useTimeout && part2Timer.FromStart >= _timeoutTimespan)
                {
                    cancellationTokenSourcePart2.Cancel();
                    part2Status = PuzzleResultStatus.Timeout;
                    break;
                }

                waitedPart2 = true;
                AnsiConsole.Write("\r");
                part2Time = part2Timer.FromStart;
                PrintRow(dayAndYear, formattedPart1Time, Formatter.FormatTime(part2Time).PadRight(10), commentMarkup);
                Thread.Sleep(20);
            }

            part2Time = waitedPart2 ? part2Time : part2Timer.FromStart;
            var formattedPart2Time = MarkupTime(part2Time, part2Status);
            AnsiConsole.Write("\r");
            PrintRow(dayAndYear, formattedPart1Time, formattedPart2Time, commentMarkup);
            AnsiConsole.WriteLine();
        }

        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }

    private string MarkupTime(TimeSpan time, PuzzleResultStatus status)
    {
        if (status is PuzzleResultStatus.Correct)
            return MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Green);
        if (status is PuzzleResultStatus.Failed or PuzzleResultStatus.Wrong)
            return MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Red);
        if (status is PuzzleResultStatus.Timeout)
            return MarkupColor(PadResult($">{Formatter.FormatTime(_timeoutTimespan, 0)}"), Color.Red);
        return PadResult("");
    }

    private static string PadResult(string s) => Pad(s, ResultColumnWidth);
    private static string PadComment(string s) => Pad(s, CommentColumnWidth);
    private static string Pad(string s, int width) => s.PadRight(width);
    private static string MarkupColor(string s, Color color) => $"[{color}]{s}[/]";

    private static void PrintRow(string dayAndYear, string part1Time, string part2Time, string comment)
    {
        AnsiConsole.Markup($"| {dayAndYear} | {part1Time} | {part2Time} | {comment} |");
    }

    private static string MarkupComment(string comment) => 
        comment is null 
            ? PadComment(string.Empty) 
            : MarkupColor(PadComment(TruncateComment(comment)), Color.Yellow);

    private static string TruncateComment(string fullComment) =>
        fullComment.Length > TruncatedCommentLength
            ? fullComment[..TruncatedCommentLength] + "..."
            : fullComment;
}