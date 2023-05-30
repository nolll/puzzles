using System;
using System.Threading;
using System.Threading.Tasks;
using Aoc.Printing;
using Spectre.Console;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class InSequenceSinglePuzzleRunner : SinglePuzzleRunner
{
    private const int ResultColumnWidth = 10;
    private const int CommentColumnWidth = 24;
    private const int TruncatedCommentLength = CommentColumnWidth - 3;

    private readonly PuzzleDay _day;
    private readonly TimeSpan _timeoutTimespan;
    private readonly string _dayAndYear;
    private readonly string _commentMarkup;
    private string _part1Markup;
    private string _part2Markup;

    public InSequenceSinglePuzzleRunner(PuzzleDay day, TimeSpan timeoutTimespan)
    {
        _day = day;
        _timeoutTimespan = timeoutTimespan;

        var dayStr = _day.Day.ToString().PadLeft(2, '0');
        _dayAndYear = $"Day {dayStr} {_day.Year}";
        _commentMarkup = MarkupComment(_day.Puzzle.Comment);
        _part1Markup = PadResult(string.Empty);
        _part2Markup = PadResult(string.Empty);
    }

    public void Run()
    {
        PrintRow();
        RunPart(_day.Puzzle.RunPart1, UpdatePart1Result);
        RunPart(_day.Puzzle.RunPart2, UpdatePart2Result);
        AnsiConsole.WriteLine();
    }

    private void RunPart(Func<PuzzleResult> runFunc, Action<string> updateResultFunc)
    {
        var status = PuzzleResultStatus.Empty;
        var timer = new Timer();
        var time = TimeSpan.Zero;
        var waited = false;
        var cancellation = new CancellationTokenSource();
        var task = Task.Run(() => status = runFunc().Status, cancellation.Token);
        while (!task.IsCompleted)
        {
            if (timer.FromStart >= _timeoutTimespan)
            {
                cancellation.Cancel();
                status = PuzzleResultStatus.Timeout;
                break;
            }

            waited = true;
            time = timer.FromStart;
            updateResultFunc(PadResult(Formatter.FormatTime(time)));
            PrintRow();
            Thread.Sleep(ProgressWaitTime);
        }

        time = waited ? time : timer.FromStart;
        updateResultFunc(MarkupTime(time, status));
        PrintRow();
    }

    private void UpdatePart1Result(string markup) => _part1Markup = markup;
    private void UpdatePart2Result(string markup) => _part2Markup = markup;

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

    private void PrintRow()
    {
        AnsiConsole.Markup($"\r| {_dayAndYear} | {_part1Markup} | {_part2Markup} | {_commentMarkup} |");
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