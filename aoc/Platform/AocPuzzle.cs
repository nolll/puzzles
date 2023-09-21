using System;
using System.IO;
using common.Puzzles;

namespace Aoc.Platform;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    protected sealed override string GetFilePath(Type t)
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(t);
        var paddedDay = day.ToString().PadLeft(2, '0');
        return Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Puzzles",
            $"Year{year}",
            $"Day{paddedDay}",
            $"Year{year}Day{paddedDay}.txt");
    }
}