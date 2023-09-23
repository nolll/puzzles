using System;
using System.IO;
using Common.Puzzles;

namespace Aoc;

public abstract class AocPuzzle : TwoPartsPuzzle
{
    protected sealed override string GetInputFilePath(Type t)
    {
        var (year, day) = AocPuzzleParser.GetYearAndDay(t);
        var paddedDay = day.ToString().PadLeft(2, '0');
        return Path.Combine(
            "Puzzles",
            $"Year{year}",
            $"Day{paddedDay}",
            $"Year{year}Day{paddedDay}.txt");
    }
}