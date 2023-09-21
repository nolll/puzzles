using System;
using System.IO;
using common.Puzzles;

namespace Aoc.Platform;

public abstract class AocPuzzle : Puzzle
{
    public abstract string Title { get; }
    public virtual string Comment => null;
    public virtual bool IsSlow => false;
    public virtual bool NeedsRewrite => false;
    public virtual bool IsFunToOptimize => false;

    public virtual PuzzleResult RunPart1()
    {
        return null;
    }

    public virtual PuzzleResult RunPart2()
    {
        return null;
    }

    protected sealed override string GetFilePath(Type t)
    {
        var (year, day) = PuzzleParser.GetYearAndDay(t);
        var paddedDay = day.ToString().PadLeft(2, '0');
        return Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Puzzles",
            $"Year{year}",
            $"Day{paddedDay}",
            $"Year{year}Day{paddedDay}.txt");
    }
}