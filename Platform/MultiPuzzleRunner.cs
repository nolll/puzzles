using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Aoc.Platform;

public class MultiPuzzleRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiPuzzleRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<PuzzleDay> days)
    {
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.WriteLine("| day         | part 1     | part 2     | comment                  |");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");

        foreach (var day in days)
        {
            new TableRowSinglePuzzleRunner(day, _timeoutTimespan).Run();
        }

        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }
}