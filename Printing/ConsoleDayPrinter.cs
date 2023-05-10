using System;
using Aoc.Platform;

namespace Aoc.Printing;

public abstract class ConsoleDayPrinter
{
    private readonly ConsoleColor _defaultColor;

    protected ConsoleDayPrinter()
    {
        _defaultColor = Console.ForegroundColor;
    }

    protected void ResetColor()
    {
        Console.ForegroundColor = _defaultColor;
    }

    protected void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    protected static ConsoleColor GetColor(PuzzleResult result)
    {
        return result.Status switch
        {
            PuzzleResultStatus.Failed or PuzzleResultStatus.Missing or PuzzleResultStatus.Timeout
                or PuzzleResultStatus.Wrong => ConsoleColor.Red,
            PuzzleResultStatus.Correct => ConsoleColor.Green,
            _ => ConsoleColor.Yellow
        };
    }
}