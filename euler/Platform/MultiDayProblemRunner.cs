using Spectre.Console;

namespace Euler.Platform;

public class MultiDayProblemRunner
{
    private readonly TimeSpan _timeoutTimespan;

    public MultiDayProblemRunner(int timeoutSeconds)
    {
        _timeoutTimespan = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public void Run(IEnumerable<ProblemWrapper> problems)
    {
        var problemList = problems.ToList();
        AnsiConsole.Cursor.Show(false);
        AnsiConsole.WriteLine($"Running {problemList.Count} problems");
        AnsiConsole.WriteLine("-------------------------------------------------------");
        AnsiConsole.WriteLine("| problem     | result     | comment                  |");
        AnsiConsole.WriteLine("-------------------------------------------------------");

        foreach (var problem in problemList)
        {
            new InSequenceSingleProblemRunner(problem, _timeoutTimespan).Run();
        }

        AnsiConsole.WriteLine("-------------------------------------------------------");
        AnsiConsole.Cursor.Show(true);
    }
}