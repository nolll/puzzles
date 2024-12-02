using System.Threading;
using System.Threading.Tasks;
using Pzl.Client.Debugging;
using Pzl.Client.Formatting;
using Pzl.Client.Running.Results;
using Pzl.Common;
using Spectre.Console;
using Timer = Pzl.Client.Timing.Timer;

namespace Pzl.Client.Running.Runners;

public class StandaloneSinglePuzzleRunner(
    PuzzleFactory puzzleFactory,
    ResultVerifier resultVerifier,
    PuzzleDefinition puzzle,
    RunMode runMode)
    : SinglePuzzleRunner
{
    private const int StatusPadding = 15;

    public void Run()
    {
        if(runMode.IsDebug)
            RunDebugMode();
        else
            RunStandardMode();
    }

    private void RunStandardMode()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(puzzle);
        
        var instance = puzzleFactory.CreateInstance(puzzle);
        
        for (var i = 0; i < instance.Funcs.Length; i++)
        {
            var func = instance.Funcs[i];
            
            AnsiConsole.WriteLine();
            RunAndPrintPuzzleResult(i + 1, func);
        }

        AnsiConsole.Cursor.Show(true);
    }

    private void RunDebugMode()
    {
        WriteHeader(puzzle);
        var instance = puzzleFactory.CreateInstance(puzzle);
        
        foreach (var func in instance.Funcs)
        {
            var result = func.Invoke();

            AnsiConsole.WriteLine(result.Answer);
        }
    }

    private static void WriteHeader(PuzzleDefinition puzzle)
    {
        AnsiConsole.WriteLine($"{puzzle.Title}");
        
        if (!string.IsNullOrEmpty(puzzle.Name))
            AnsiConsole.WriteLine(puzzle.Name);
        
        if (puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{puzzle.Comment}[/]");
    }
    
    private void RunAndPrintPuzzleResult(int puzzleIndex, PuzzleFunction func)
    {
        var result = RunPuzzle(puzzleIndex, func);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }
    
    private VerifiedPuzzleResult RunPuzzle(int puzzleIndex, PuzzleFunction func)
    {
        PuzzleResult? result = null;
        PrintTime(puzzleIndex);
        var timer = new Timer();
        
        var task = Task.Run(() =>
        { 
            result = func.Invoke();
        });
        
        while (!task.IsCompleted)
        {
            PrintTime(puzzleIndex, timer.FromStart);
            Thread.Sleep(ProgressWaitTime);
        }

        if (task.IsFaulted && task.Exception is not null)
            throw task.Exception;

        if (task.IsFaulted)
            return VerifiedPuzzleResult.Failed;

        if (result is not null)
            return resultVerifier.Verify(result);
            
        return VerifiedPuzzleResult.Empty;
    }

    private static void PrintTime(int puzzleNumber, TimeSpan? time = null)
    {
        var formattedTime = time is not null
            ? Formatter.FormatTime(time.Value)
            : string.Empty;

        AnsiConsole.Write($"\rPart {puzzleNumber}: {formattedTime}".PadRight(StatusPadding));
    }
    
    private static void WriteAnswer(VerifiedPuzzleResult? result)
    {
        if (result is null)
            AnsiConsole.MarkupLine(MarkupColor("Missing", Color.Red));
        else if (result.Status is ResultStatus.Missing)
            AnsiConsole.MarkupLine(MarkupColor("No puzzle", Color.Grey));
        else if (result.Status is ResultStatus.Correct)
            WriteAnswer(result, Color.Green);
        else if (result.Status is ResultStatus.Failed or ResultStatus.Timeout or ResultStatus.Wrong)
            WriteAnswer(result, Color.Red);
        else
            WriteAnswer(result, Color.Yellow);
    }

    private static void WriteAnswer(VerifiedPuzzleResult result, Color color)
    {
        AnsiConsole.MarkupLine(MarkupColor(result.Answer.Answer, color));
        if(result.Status == ResultStatus.Completed)
            AnsiConsole.MarkupLine(MarkupColor(result.Hash, Color.Grey));
    }
}