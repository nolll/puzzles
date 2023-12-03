using Puzzles.Common.Puzzles;
using Spectre.Console;

namespace Puzzles.Common.Runners;

public class MultiPuzzleRunner
{
    private const int TitleLength = 11;
    private const int ResultLength = 10;
    private const int CommentLength = 24;

    private readonly IList<Puzzle> _puzzles;
    private readonly int _funcCount;
    private readonly TimeSpan _timeoutTimespan;
    private readonly PuzzleResultVerifier _resultVerifier;

    public MultiPuzzleRunner(IEnumerable<Puzzle> puzzles, int timeoutSeconds, string hashSeed, bool isDebugMode)
    {
        _puzzles = puzzles.ToList();
        _funcCount = _puzzles.Max(o => o.RunFunctions.Count);
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
        _resultVerifier = new PuzzleResultVerifier(hashSeed);
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        PrintHeader();

        foreach (var puzzle in _puzzles)
        {
            new InSequenceSinglePuzzleRunner(
                puzzle, 
                _timeoutTimespan, 
                _resultVerifier,
                TitleLength, 
                ResultLength, 
                CommentLength,
                _funcCount).Run();
        }

        PrintFooter();
        AnsiConsole.Cursor.Show(true);
    }

    private void PrintHeader()
    {
        var partTitles = _funcCount > 1
            ? Enumerable.Range(1, _funcCount).Select(o => $"part {o}")
            : new List<string> { "result" };
        var paddedPartTitles = partTitles.Select(o => o.PadRight(10));
        var variableParts = string.Join(" | ", paddedPartTitles);

        AnsiConsole.WriteLine($"Running {_puzzles.Count} puzzles");
        PrintDivider();
        AnsiConsole.WriteLine($"| {"puzzle",-TitleLength} | {variableParts} | {"comment",-CommentLength} |");
        PrintDivider();
    }

    private void PrintFooter()
    {
        PrintDivider();
    }

    private void PrintDivider()
    {
        var partsDividers = Enumerable.Range(1, _funcCount).Select(_ => "----------");
        var variableDividers = string.Join("---", partsDividers);
        var divider = $"----------------{variableDividers}-----------------------------";
        AnsiConsole.WriteLine(divider);
    }
}