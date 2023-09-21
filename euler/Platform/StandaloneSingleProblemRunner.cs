using System.Threading;
using System.Threading.Tasks;
using common.Formatting;
using Spectre.Console;
using Color = System.Drawing.Color;
using Timer = common.Timing.Timer;

namespace Euler.Platform;

public class StandaloneSingleProblemRunner : SingleProblemRunner
{
    private readonly ProblemWrapper _problem;
    private const int StatusPadding = 15;

    public StandaloneSingleProblemRunner(ProblemWrapper problem)
    {
        _problem = problem;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_problem);
        AnsiConsole.WriteLine();
        RunAndPrintProblemResult(() => _problem.Problem.Run());
        AnsiConsole.Cursor.Show(true);
    }

    private static void WriteHeader(ProblemWrapper problem)
    {
        AnsiConsole.WriteLine($"Problem {problem.Id}:");
        AnsiConsole.WriteLine(problem.Problem.Name);
        if (problem.Problem.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{problem.Problem.Comment}[/]");
    }

    private static void RunAndPrintProblemResult(Func<ProblemResult> problemFunc)
    {
        var result = RunProblem(problemFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private static ProblemResult? RunProblem(Func<ProblemResult> problemFunc)
    {
        ProblemResult? result = null;
        PrintTime();
        var timer = new Timer();
        var task = Task.Run(() => result = problemFunc());
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

    private static void WriteAnswer(ProblemResult? result)
    {
        if (result is null)
            AnsiConsole.MarkupLine(MarkupColor("Missing", Color.Red));
        else if (result.Status is ProblemResultStatus.Empty)
            AnsiConsole.WriteLine("No problem implemented");
        else if (result.Status is ProblemResultStatus.Correct)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Green));
        else if (result.Status is ProblemResultStatus.Failed or ProblemResultStatus.Timeout or ProblemResultStatus.Wrong)
            AnsiConsole.MarkupLine(MarkupColor(result.Answer, Color.Red));
        else
            AnsiConsole.MarkupLine(MarkupColor(result.Answer ?? "", Color.Yellow));
    }
}