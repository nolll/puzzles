using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace Aoc.Platform;

public class MultiDayPuzzleRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiDayPuzzleRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<PuzzleDay> days)
    {
        var dayList = days.ToList();
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine($"Running {dayList.Count} days");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.WriteLine("| day         | part 1     | part 2     | comment                  |");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");

        foreach (var day in dayList)
        {
            new InSequenceSinglePuzzleRunner(day, _timeoutTimespan).Run();
        }

        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }
}