using System.Threading;
using System.Threading.Tasks;
using common.Formatting;
using common.Puzzles;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = common.Timing.Timer;

namespace AquaQ.Platform;

public class StandaloneSingleChallengeRunner : SingleChallengeRunner
{
    private readonly ChallengeWrapper _challenge;
    private const int StatusPadding = 15;

    public StandaloneSingleChallengeRunner(ChallengeWrapper challenge)
    {
        _challenge = challenge;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_challenge);
        AnsiConsole.WriteLine();
        RunAndPrintChallengeResult(() => _challenge.Challenge.Run());
        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteHeader(ChallengeWrapper challenge)
    {
        AnsiConsole.WriteLine($"Challenge {challenge.Id}:");
        AnsiConsole.WriteLine(challenge.Challenge.Name);
        if (challenge.Challenge.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{challenge.Challenge.Comment}[/]");
    }

    private static void RunAndPrintChallengeResult(Func<PuzzleResult> challengeFunc)
    {
        var result = RunChallenge(challengeFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private static PuzzleResult? RunChallenge(Func<PuzzleResult> challengeFunc)
    {
        PuzzleResult? result = null;
        PrintTime();
        var timer = new Timer();
        var task = Task.Run(() => result = challengeFunc());
        while (!task.IsCompleted)
        {
            PrintTime(timer.FromStart);
            Thread.Sleep(ProgressWaitTime);
        }

        return task.IsFaulted ? PuzzleResult.Failed : result;
    }

    private static void PrintTime(TimeSpan? time = null)
    {
        var formattedTime = time is not null
            ? Formatter.FormatTime(time.Value)
            : string.Empty;

        AnsiConsole.Write($"\r{formattedTime}".PadRight(StatusPadding));
    }

    private static void WriteAnswer(PuzzleResult? result)
    {
        if (result is null)
            AnsiConsole.MarkupLine(MarkupColor("Missing", Color.Red));
        else if (result.Status is PuzzleResultStatus.Empty)
            AnsiConsole.WriteLine("No challenge implemented");
        else if (result.Status is PuzzleResultStatus.Correct)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Green));
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Red));
        else
            AnsiConsole.MarkupLine(MarkupColor(result.Answer ?? "", Color.Yellow));
    }
}