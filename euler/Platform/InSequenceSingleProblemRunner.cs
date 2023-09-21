using common.Formatting;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = common.Timing.Timer;

namespace Euler.Platform;

public class InSequenceSingleProblemRunner : SingleProblemRunner
{
    private const int ResultColumnWidth = 10;
    private const int CommentColumnWidth = 24;
    private const int TruncatedCommentLength = CommentColumnWidth - 3;

    private readonly ProblemWrapper _problem;
    private readonly TimeSpan _timeoutTimespan;
    private readonly string _problemStr;
    private readonly string _commentMarkup;
    private string _markup;

    public InSequenceSingleProblemRunner(ProblemWrapper problem, TimeSpan timeoutTimespan)
    {
        _problem = problem;
        _timeoutTimespan = timeoutTimespan;

        var numberStr = _problem.Id.ToString().PadLeft(3, '0');
        _problemStr = $"Problem {numberStr}";
        _commentMarkup = MarkupComment(_problem.Problem.Comment ?? "");
        _markup = PadResult(string.Empty);
    }

    public void Run()
    {
        PrintRow();
        RunPart(() => _problem.Problem.Run(), UpdatePart1Result);
        AnsiConsole.WriteLine();
    }

    private void RunPart(Func<ProblemResult> runFunc, Action<string> updateResultFunc)
    {
        var status = ProblemResultStatus.Empty;
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
                status = ProblemResultStatus.Timeout;
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

    private void UpdatePart1Result(string markup) => _markup = markup;

    private string MarkupTime(TimeSpan time, ProblemResultStatus status)
    {
        return status switch
        {
            ProblemResultStatus.Correct =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Green),
            ProblemResultStatus.Failed or ProblemResultStatus.Wrong =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Red),
            ProblemResultStatus.Timeout =>
                MarkupColor(PadResult($">{Formatter.FormatTime(_timeoutTimespan, 0)}"), Color.Red),
            _ => PadResult("")
        };
    }

    private static string PadResult(string s) => Pad(s, ResultColumnWidth);
    private static string PadComment(string s) => Pad(s, CommentColumnWidth);
    private static string Pad(string s, int width) => s.PadRight(width);

    private void PrintRow() =>
        AnsiConsole.Markup($"\r| {_problemStr} | {_markup} | {_commentMarkup} |");

    private static string MarkupComment(string comment) =>
        comment is null
            ? PadComment(string.Empty)
            : MarkupColor(PadComment(TruncateComment(comment)), Color.Yellow);

    private static string TruncateComment(string fullComment) =>
        fullComment.Length > TruncatedCommentLength
            ? fullComment[..TruncatedCommentLength] + "..."
            : fullComment;
}