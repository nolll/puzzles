using System.Threading;
using System.Threading.Tasks;
using Puzzles.Common.Formatting;
using Puzzles.Common.Puzzles;
using Spectre.Console;
using Timer = Puzzles.Common.Timing.Timer;

namespace Pzl.Cli.Runners;

public class StandaloneSinglePuzzleRunner : SinglePuzzleRunner
{
    private readonly Puzzle _puzzle;
    private readonly bool _isDebugMode;
    private const int StatusPadding = 15;

    private readonly PuzzleResultVerifier _resultVerifier;

    public StandaloneSinglePuzzleRunner(Puzzle puzzle, string hashSeed, bool isDebugMode)
    {
        _puzzle = puzzle;
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
        WriteHeader(_puzzle);

        for (var i = 0; i < _puzzle.RunFunctions.Count; i++)
        {
            var runFunc = _puzzle.RunFunctions[i];
            AnsiConsole.WriteLine();
            RunAndPrintPuzzleResult(i + 1, runFunc);
        }

        AnsiConsole.Cursor.Show(true);
    }

    private void RunDebugMode()
    {
        WriteHeader(_puzzle);

        foreach (var runFunc in _puzzle.RunFunctions)
        {
            var result = runFunc();
            AnsiConsole.WriteLine(result.Answer);
        }
    }

    private static void WriteHeader(Puzzle puzzle)
    {
        AnsiConsole.WriteLine($"{puzzle.Title}:");
        AnsiConsole.WriteLine(puzzle.Name);
        if (puzzle.Comment is not null)
            AnsiConsole.MarkupLine($"[yellow]{puzzle.Comment}[/]");
    }

    private void RunAndPrintPuzzleResult(int puzzleIndex, Func<PuzzleResult> puzzleFunc)
    {
        var result = RunPuzzle(puzzleIndex, puzzleFunc);
        AnsiConsole.WriteLine();
        WriteAnswer(result);
    }

    private VerifiedPuzzleResult RunPuzzle(int puzzleIndex, Func<PuzzleResult> puzzleFunc)
    {
        PuzzleResult? result = null;
        PrintTime(puzzleIndex);
        var timer = new Timer();
        var task = Task.Run(() => result = puzzleFunc());
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