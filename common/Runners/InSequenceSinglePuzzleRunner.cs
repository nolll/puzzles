using Common.Formatting;
using Common.Puzzles;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = Common.Timing.Timer;

namespace Common.Runners;

public class InSequenceSinglePuzzleRunner : SinglePuzzleRunner
{
    private const int ResultColumnWidth = 10;
    private const int CommentColumnWidth = 24;
    private const int TruncatedCommentLength = CommentColumnWidth - 3;

    private readonly PuzzleWrapper _wrapper;
    private readonly TimeSpan _timeoutTimespan;
    private readonly string _title;
    private readonly string _commentMarkup;
    private readonly string[] _markups;

    public InSequenceSinglePuzzleRunner(PuzzleWrapper wrapper, TimeSpan timeoutTimespan)
    {
        _wrapper = wrapper;
        _timeoutTimespan = timeoutTimespan;

        _title = _wrapper.ListTitle.PadRight(11);
        _commentMarkup = MarkupComment(_wrapper.Puzzle.Comment);
        _markups = new string[_wrapper.Puzzle.RunFunctions.Count];
        for (var i = 0; i < _wrapper.Puzzle.RunFunctions.Count; i++)
        {
            _markups[i] = PadResult(string.Empty);
        }
    }

    public void Run()
    {
        PrintRow();
        for (var i = 0; i < _wrapper.Puzzle.RunFunctions.Count; i++)
        {
            var runFunc = _wrapper.Puzzle.RunFunctions[i];
            RunPart(() => runFunc(), i);
        }
        AnsiConsole.WriteLine();
    }

    private void RunPart(Func<PuzzleResult> runFunc, int index)
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
            UpdateResult(index, PadResult(Formatter.FormatTime(time)));
            PrintRow();
            Thread.Sleep(ProgressWaitTime);
        }

        status = task.IsFaulted ? PuzzleResultStatus.Failed : status;
        time = waited ? time : timer.FromStart;
        UpdateResult(index, MarkupTime(time, status));
        PrintRow();
    }

    private void UpdateResult(int index, string markup) => _markups[index] = markup;

    private string MarkupTime(TimeSpan time, PuzzleResultStatus status)
    {
        return status switch
        {
            PuzzleResultStatus.Correct =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Green),
            PuzzleResultStatus.Failed or PuzzleResultStatus.Wrong => 
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Red),
            PuzzleResultStatus.Timeout => 
                MarkupColor(PadResult($">{Formatter.FormatTime(_timeoutTimespan, 0)}"), Color.Red),
            _ => PadResult("")
        };
    }

    private static string PadResult(string s) => Pad(s, ResultColumnWidth);
    private static string PadComment(string s) => Pad(s, CommentColumnWidth);
    private static string Pad(string s, int width) => s.PadRight(width);

    private void PrintRow()
    {
        var results = string.Join(" | ", _markups);
        AnsiConsole.Markup($"\r| {_title} | {results} | {_commentMarkup} |");
    }

    private static string MarkupComment(string? comment) =>
        comment is null
            ? PadComment(string.Empty)
            : MarkupColor(PadComment(TruncateComment(comment)), Color.Yellow);

    private static string TruncateComment(string fullComment) =>
        fullComment.Length > TruncatedCommentLength
            ? fullComment[..TruncatedCommentLength] + "..."
            : fullComment;
}