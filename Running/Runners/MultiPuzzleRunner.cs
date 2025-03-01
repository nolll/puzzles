﻿using Pzl.Client.Running.Results;
using Pzl.Common;
using Spectre.Console;

namespace Pzl.Client.Running.Runners;

public class MultiPuzzleRunner
{
    private const int TitleLength = 11;
    private const int ResultLength = 10;
    private const int CommentLength = 24;

    private readonly PuzzleFactory _puzzleFactory;
    private readonly List<PuzzleDefinition> _definitions;
    private readonly int _funcCount;
    private readonly TimeSpan _timeoutTimespan;
    private readonly ResultVerifier _resultVerifier;

    public MultiPuzzleRunner(
        PuzzleFactory puzzleFactory, 
        ResultVerifier resultVerifier,
        List<PuzzleDefinition> puzzles, 
        int timeoutSeconds)
    {
        _puzzleFactory = puzzleFactory;
        _definitions = puzzles;
        _funcCount = _definitions.Max(o => o.NumberOfParts);
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
        _resultVerifier = resultVerifier;
    }

    public void Run()
    {
        AnsiConsole.Cursor.Show(false);
        PrintHeader();

        foreach (var puzzle in _definitions)
        {
            new InSequenceSinglePuzzleRunner(
                _puzzleFactory,
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

        AnsiConsole.WriteLine($"Running {_definitions.Count} puzzles");
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