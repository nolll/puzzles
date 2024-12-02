using System.Threading;
using System.Threading.Tasks;
using Pzl.Client.Formatting;
using Pzl.Client.Running.Results;
using Pzl.Common;
using Spectre.Console;
using Timer = Pzl.Client.Timing.Timer;

namespace Pzl.Client.Running.Runners;

public class InSequenceSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly PuzzleFactory _puzzleFactory;
    private readonly PuzzleDefinition _definition;
    private readonly TimeSpan _timeoutTimespan;
    private readonly ResultVerifier _resultVerifier;
    private readonly int _resultLength;
    private readonly int _commentLength;
    private readonly int _truncatedCommentLength;
    private readonly string _title;
    private readonly string _commentMarkup;
    private readonly string[] _markups;

    public InSequenceSinglePuzzleRunner(
        PuzzleFactory puzzleFactory,
        PuzzleDefinition puzzle, 
        TimeSpan timeoutTimespan, 
        ResultVerifier resultVerifier,
        int titleWidth,
        int resultWidth,
        int commentWidth,
        int maxFuncCount)
    {
        _puzzleFactory = puzzleFactory;
        _definition = puzzle;
        _timeoutTimespan = timeoutTimespan;
        _resultVerifier = resultVerifier;
        _resultLength = resultWidth;
        _commentLength = commentWidth;
        _truncatedCommentLength = commentWidth - 3;
        _title = puzzle.ListTitle.PadRight(titleWidth);
        _commentMarkup = MarkupComment(puzzle.Comment);
        _markups = new string[maxFuncCount];
        for (var i = 0; i < maxFuncCount; i++)
        {
            _markups[i] = PadResult(string.Empty);
        }
    }

    public void Run()
    {
        PrintRow();
        var instance = _puzzleFactory.CreateInstance(_definition);

        for (var i = 0; i < instance.Funcs.Length; i++)
        {
            var func = instance.Funcs[i];
            RunPart(() => func.Invoke(), i);
        }
        
        AnsiConsole.WriteLine();
    }

    private void RunPart(Func<PuzzleResult> runFunc, int index)
    {
        var status = ResultStatus.Missing;
        var timer = new Timer();
        var time = TimeSpan.Zero;
        var waited = false;
        var cancellation = new CancellationTokenSource();
        var task = Task.Run(() => status = _resultVerifier.Verify(runFunc()).Status, cancellation.Token);
        while (!task.IsCompleted)
        {
            if (timer.FromStart >= _timeoutTimespan)
            {
                cancellation.Cancel();
                status = ResultStatus.Timeout;
                break;
            }

            waited = true;
            time = timer.FromStart;
            UpdateResult(index, PadResult(Formatter.FormatTime(time)));
            PrintRow();
            Thread.Sleep(ProgressWaitTime);
        }

        status = task.IsFaulted ? ResultStatus.Failed : status;
        time = waited ? time : timer.FromStart;
        UpdateResult(index, MarkupTime(time, status));
        PrintRow();
    }

    private void UpdateResult(int index, string markup) => _markups[index] = markup;

    private string MarkupTime(TimeSpan time, ResultStatus status)
    {
        return status switch
        {
            ResultStatus.Correct =>
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Green),
            ResultStatus.Failed or ResultStatus.Wrong => 
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Red),
            ResultStatus.Missing =>
                MarkupColor(PadResult(""), Color.Grey),
            ResultStatus.Timeout => 
                MarkupColor(PadResult($">{Formatter.FormatTime(_timeoutTimespan, 0)}"), Color.Red),
            ResultStatus.Completed or ResultStatus.Unverified => 
                MarkupColor(PadResult(Formatter.FormatTime(time)), Color.Yellow),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }

    private string PadResult(string s) => Pad(s, _resultLength);
    private string PadComment(string s) => Pad(s, _commentLength);
    private static string Pad(string s, int width) => s.PadRight(width);

    private void PrintRow()
    {
        var results = string.Join(" | ", _markups);
        AnsiConsole.Markup($"\r| {_title} | {results} | {_commentMarkup} |");
    }

    private string MarkupComment(string? comment) =>
        comment is null
            ? PadComment(string.Empty)
            : MarkupColor(PadComment(TruncateComment(comment)), Color.Yellow);

    private string TruncateComment(string fullComment) =>
        fullComment.Length > _truncatedCommentLength
            ? fullComment[.._truncatedCommentLength] + "..."
            : fullComment;
}