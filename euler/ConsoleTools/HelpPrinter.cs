using Spectre.Console;

namespace Euler.ConsoleTools;

public static class HelpPrinter
{
    public static void Print()
    {
        AnsiConsole.WriteLine("My solutions to Project Euler.");
        AnsiConsole.WriteLine("https://github.com/nolll/euler");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Usage dotnet run -- [-p [problem]]");
        AnsiConsole.WriteLine("My Project Euler solutions.");
        AnsiConsole.WriteLine("If problem is omitted, all problems will run.");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-p    --problem   the problem to run");
        AnsiConsole.WriteLine("-s    --slow      just run problems marked as slow");
        AnsiConsole.WriteLine("-c    --comment   just run problems that has a comment");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-h    --help      display this help text");
        AnsiConsole.WriteLine("");
    }
}