using System.Threading;
using System.Threading.Tasks;
using AquaQ.Printing;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = AquaQ.Common.Timing.Timer;

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

    private static void RunAndPrintChallengeResult(Func<ChallengeResult> challengeFunc)
    {
        var result = RunChallenge(challengeFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private static ChallengeResult? RunChallenge(Func<ChallengeResult> challengeFunc)
    {
        ChallengeResult? result = null;
        PrintTime();
        var timer = new Timer();
        var task = Task.Run(() => result = challengeFunc());
        while (!task.IsCompleted)
        {
            PrintTime(timer.FromStart);
            Thread.Sleep(ProgressWaitTime);
        }

        return result;
    }

    private static void PrintTime(TimeSpan? time = null)
    {
        var formattedTime = time is not null
            ? Formatter.FormatTime(time.Value)
            : string.Empty;

        AnsiConsole.Write($"\r{formattedTime}".PadRight(StatusPadding));
    }

    private static void WriteAnswer(ChallengeResult? result)
    {
        if (result is null)
            AnsiConsole.MarkupLine(MarkupColor("Missing", Color.Red));
        else if (result.Status is ChallengeResultStatus.Empty)
            AnsiConsole.WriteLine("No challenge implemented");
        else if (result.Status is ChallengeResultStatus.Correct)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Green));
        else if (result.Status is ChallengeResultStatus.Failed or ChallengeResultStatus.Timeout or ChallengeResultStatus.Wrong)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Red));
        else
            AnsiConsole.MarkupLine(MarkupColor(result.Answer ?? "", Color.Yellow));
    }
}