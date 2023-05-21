using System;
using Aoc.Printing;
using Timer = Aoc.Common.Timing.Timer;

namespace Aoc.Platform;

public class SinglePuzzleRunner
{
    private readonly ISingleDayPrinter _singleDayPrinter;

    public SinglePuzzleRunner(ISingleDayPrinter singleDayPrinter)
    {
        _singleDayPrinter = singleDayPrinter;
    }
    
    public void Run(PuzzleDay day)
    {
        var result = RunDay(day);
        _singleDayPrinter.PrintDay(result);
    }

    private DayResult RunDay(PuzzleDay day)
    {
        var p1 = RunPuzzleWithTimer(day.Puzzle.RunPart1);
        var p2 = RunPuzzleWithTimer(day.Puzzle.RunPart2);

        return new DayResult(day, p1, p2);
    }

    private TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func)
    {
        var timer = new Timer();
        var result = RunPuzzle(func);
        return new TimedPuzzleResult(result, timer.FromStart);
    }
    
    private PuzzleResult RunPuzzle(Func<PuzzleResult> func)
    {
        return func() ?? new MissingPuzzleResult("Puzzle returned null");
    }
}