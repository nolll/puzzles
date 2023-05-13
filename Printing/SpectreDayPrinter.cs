using System;
using Aoc.Platform;

namespace Aoc.Printing;

public abstract class SpectreDayPrinter
{
    protected static string GetColor(PuzzleResult result)
    {
        return result.Status switch
        {
            PuzzleResultStatus.Failed or PuzzleResultStatus.Missing or PuzzleResultStatus.Timeout
                or PuzzleResultStatus.Wrong => "red",
            PuzzleResultStatus.Correct => "green",
            _ => "yellow"
        };
    }
}