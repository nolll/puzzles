using Spectre.Console;

namespace AquaQ.ConsoleTools;

public static class HelpPrinter
{
    public static void Print()
    {
        AnsiConsole.WriteLine("My solutions to Project Euler.");
        AnsiConsole.WriteLine("https://github.com/nolll/euler");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("Usage dotnet run -- [-c [challenge]]");
        AnsiConsole.WriteLine("My AquaQ Challenge solutions.");
        AnsiConsole.WriteLine("If challenge is omitted, all challenges will run.");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-c    --challenge the challenge to run");
        AnsiConsole.WriteLine("-s    --slow      just run challenges marked as slow");
        AnsiConsole.WriteLine("-n    --notes     just run challenges that has notes");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine("-h    --help      display this help text");
        AnsiConsole.WriteLine("");
    }
}