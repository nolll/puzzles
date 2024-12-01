using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Pzl.Client.Formatting;
using Pzl.Client.Running.Results;
using Pzl.Common;
using Spectre.Console;
using Timer = Pzl.Client.Timing.Timer;

namespace Pzl.Client.Running.Runners;

public class StandaloneSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly PuzzleResultVerifier _resultVerifier;
    private readonly PuzzleDefinition _definition;
    private readonly bool _isDebugMode;
    private const int StatusPadding = 15;

    public StandaloneSinglePuzzleRunner(
        PuzzleDefinition puzzle, 
        string hashSeed,
        bool isDebugMode)
    {
        _definition = puzzle;
        _isDebugMode = isDebugMode;
        _resultVerifier = new PuzzleResultVerifier(hashSeed);
    }

    public void Run()
    {
        if(_isDebugMode)
            RunDebugMode();
        else
            RunStandardMode();
    }

    private void RunStandardMode()
    {
        AnsiConsole.Cursor.Show(false);
        WriteHeader(_definition);
        
        var inputs = FileReader.ReadInputs(_definition);
        var instance = PuzzleFactory.CreateInstance(_definition);
        var funcs = _definition.Type.GetMethods()
            .Where(o => o is { IsPublic: true, IsStatic: false } && o.ReturnType == typeof(PuzzleResult))
            .OrderBy(o => o.Name)
            .ToArray();
        
        for (var i = 0; i < funcs.Length; i++)
        {
            var input = _definition.HasUniqueInputsPerPart
                ? inputs[i]
                : inputs[0];

            AnsiConsole.WriteLine();
            RunAndPrintPuzzleResult(i + 1, instance, funcs[i], input);
        }

        AnsiConsole.Cursor.Show(true);
    }

    private void RunDebugMode()
    {
        WriteHeader(_definition);
        var inputs = FileReader.ReadInputs(_definition);
        var instance = PuzzleFactory.CreateInstance(_definition);
        var funcs = _definition.Type.GetMethods()
            .Where(o => o is { IsPublic: true, IsStatic: false } && o.ReturnType == typeof(PuzzleResult))
            .OrderBy(o => o.Name)
            .ToArray();
        
        for (var i = 0; i < funcs.Length; i++)
        {
            var input = _definition.HasUniqueInputsPerPart
                ? inputs[i]
                : inputs[0];
            var result = funcs[i].Invoke(instance, [input]);
            if (result is not PuzzleResult puzzleResult)
                throw new Exception("Function did not return a PuzzleResult");
            
            AnsiConsole.WriteLine(puzzleResult.Answer);
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
    
    private void RunAndPrintPuzzleResult(int puzzleIndex, Puzzle puzzle, MethodInfo func, string input)
    {
        var result = RunPuzzle(puzzleIndex, puzzle, func, input);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }
    
    private VerifiedPuzzleResult RunPuzzle(int puzzleIndex, Puzzle puzzle, MethodInfo func, string input)
    {
        PuzzleResult? result = null;
        PrintTime(puzzleIndex);
        var timer = new Timer();
        
        var task = Task.Run(() =>
        {
            var obj = func.Invoke(puzzle, [input]);
            if (obj is PuzzleResult puzzleResult)
                result = puzzleResult;
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
            return _resultVerifier.Verify(result);
            
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
        else if (result.Status is PuzzleResultStatus.Missing)
            AnsiConsole.MarkupLine(MarkupColor("No puzzle", Color.Grey));
        else if (result.Status is PuzzleResultStatus.Correct)
            WriteAnswer(result, Color.Green);
        else if (result.Status is PuzzleResultStatus.Failed or PuzzleResultStatus.Timeout or PuzzleResultStatus.Wrong)
            WriteAnswer(result, Color.Red);
        else
            WriteAnswer(result, Color.Yellow);
    }

    private static void WriteAnswer(VerifiedPuzzleResult result, Color color)
    {
        AnsiConsole.MarkupLine(MarkupColor(result.Answer.Answer, color));
        if(result.Status == PuzzleResultStatus.Completed)
            AnsiConsole.MarkupLine(MarkupColor(result.Hash, Color.Grey));
    }
}