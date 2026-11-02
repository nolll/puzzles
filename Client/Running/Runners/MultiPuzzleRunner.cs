using Pzl.Client.Running.Results;
using Pzl.Common;

namespace Pzl.Client.Running.Runners;

public class MultiPuzzleRunner
{
    private const int TitleWidth = 11;
    private const int ResultWidth = 10;
    private const int BorderWidth = 2;
    private const int DividerWidth = 3;
    private const int MinWindowWidth = 80;

    private readonly PuzzleFactory _puzzleFactory;
    private readonly List<PuzzleDefinition> _definitions;
    private readonly int _funcCount;
    private readonly int _nameWidth;
    private readonly int _commentWidth;
    private readonly int _totalWidth;
    private readonly TimeSpan _timeoutTimespan;
    private readonly ResultVerifier _resultVerifier;

    public MultiPuzzleRunner(PuzzleFactory puzzleFactory, ResultVerifier resultVerifier, List<PuzzleDefinition> puzzles, int timeoutSeconds)
    {
        _puzzleFactory = puzzleFactory;
        _definitions = puzzles;
        _funcCount = _definitions.Max(o => o.NumberOfParts);
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
        _resultVerifier = resultVerifier;
        
        var windowWidth = GetWindowWidth();
        var usedWidth = BorderWidth * 2 + TitleWidth + DividerWidth * _funcCount + ResultWidth * _funcCount;
        var maxNameWidth = _definitions.Max(o => o.Name.Length);
        var maxCommentWidth = _definitions.Max(o => o.Comment?.Length ?? 0);

        var availableWidth = windowWidth - usedWidth;
        if (maxNameWidth + DividerWidth <= availableWidth)
        {
            _nameWidth = maxNameWidth;
            usedWidth += _nameWidth + DividerWidth;
        }
        
        availableWidth = windowWidth - usedWidth;
        if (maxCommentWidth + DividerWidth <= availableWidth)
        {
            _commentWidth = maxCommentWidth;
            usedWidth += _commentWidth + DividerWidth;
        }

        _totalWidth = usedWidth;
    }

    public void Run()
    {
        Printer.HideCursor();
        PrintHeader();

        foreach (var puzzle in _definitions)
        {
            new InSequenceSinglePuzzleRunner(
                _puzzleFactory,
                puzzle, 
                _timeoutTimespan, 
                _resultVerifier,
                TitleWidth, 
                ResultWidth, 
                _commentWidth,
                _nameWidth,
                _funcCount).Run();
        }

        PrintFooter();
        Printer.ShowCursor();
    }

    private void PrintHeader()
    {
        var partTitles = _funcCount > 1
            ? Enumerable.Range(1, _funcCount).Select(o => $"part {o}")
            : new List<string> { "result" };
        var paddedPartTitles = partTitles.Select(o => o.PadRight(10));
        var variableParts = string.Join(" | ", paddedPartTitles);

        Printer.WriteLine($"Running {_definitions.Count} puzzles");
        PrintDivider();
        var titleParts = new List<string>
        {
            "puzzle".PadRight(TitleWidth),
            variableParts
        };
        
        if(_nameWidth > 0)
            titleParts.Add("name".PadRight(_nameWidth));
        
        if(_commentWidth > 0)
            titleParts.Add("comment".PadRight(_commentWidth));
        
        Printer.WriteLine($"| {string.Join(" | ", titleParts)} |");
        PrintDivider();
    }

    private void PrintFooter() => PrintDivider();
    private void PrintDivider() => Printer.WriteLine(string.Concat(Enumerable.Repeat("-", _totalWidth)));

    private static int GetWindowWidth()
    {
        try
        {
            return Console.WindowWidth;
        }
        catch
        {
            return MinWindowWidth;
        }
    }
}