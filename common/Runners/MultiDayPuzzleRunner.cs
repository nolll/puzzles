using common.Puzzles;
using Spectre.Console;

namespace common.Runners;

public class MultiDayPuzzleRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiDayPuzzleRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<PuzzleWrapper> days)
    {
        var dayList = days.ToList();
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine($"Running {dayList.Count} puzzles");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.WriteLine("| puzzle      | part 1     | part 2     | comment                  |");
        AnsiConsole.WriteLine("--------------------------------------------------------------------");

        foreach (var day in dayList)
        {
            new InSequenceSinglePuzzleRunner(day, _timeoutTimespan).Run();
        }

        AnsiConsole.WriteLine("--------------------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }
}