using System.Threading;
using System.Threading.Tasks;
using AquaQ.Printing;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = AquaQ.Common.Timing.Timer;

namespace AquaQ.Platform;

public class InSequenceSingleChallengeRunner : SingleChallengeRunner
{
    private const int ResultColumnWidth = 10;
    private const int CommentColumnWidth = 24;
    private const int TruncatedCommentLength = CommentColumnWidth - 3;

    private readonly ChallengeWrapper _challenge;
    private readonly TimeSpan _timeoutTimespan;
    private readonly string _challengeStr;
    private readonly string _commentMarkup;
    private string _markup;

    public InSequenceSingleChallengeRunner(ChallengeWrapper challenge, TimeSpan timeoutTimespan)
    {
        _challenge = challenge;
        _timeoutTimespan = timeoutTimespan;

        var numberStr = _challenge.Id.ToString().PadLeft(2, '0');
        _challengeStr = $"Challenge {numberStr}";
        _commentMarkup = MarkupComment(_challenge.Challenge.Comment ?? "");
        _markup = PadResult(string.Empty);
    }

    public void Run()
    {
        PrintRow();
        RunPart(() => _challenge.Challenge.Run(), UpdatePart1Result);
        AnsiConsole.WriteLine();
    }

    private void RunPart(Func<ChallengeResult> runFunc, Action<string> updateResultFunc)
    {
        var status = ChallengeResultStatus.Empty;
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
                status = ChallengeResultStatus.Timeout;
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

    private string MarkupTime(TimeSpan time, ChallengeResultStatus status)
    {
        return status switch
        {
            ChallengeResultStatus.Correct =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Green),
            ChallengeResultStatus.Failed or ChallengeResultStatus.Wrong =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Red),
            ChallengeResultStatus.Timeout =>
                MarkupColor(PadResult($">{Formatter.FormatTime(_timeoutTimespan, 0)}"), Color.Red),
            _ => PadResult("")
        };
    }

    private static string PadResult(string s) => Pad(s, ResultColumnWidth);
    private static string PadComment(string s) => Pad(s, CommentColumnWidth);
    private static string Pad(string s, int width) => s.PadRight(width);

    private void PrintRow() =>
        AnsiConsole.Markup($"\r| {_challengeStr} | {_markup} | {_commentMarkup} |");

    private static string MarkupComment(string comment) =>
        comment is null
            ? PadComment(string.Empty)
            : MarkupColor(PadComment(TruncateComment(comment)), Color.Yellow);

    private static string TruncateComment(string fullComment) =>
        fullComment.Length > TruncatedCommentLength
            ? fullComment[..TruncatedCommentLength] + "..."
            : fullComment;
}